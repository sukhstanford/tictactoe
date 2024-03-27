using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace tictactoe
{
    //internal class Program
    //{
    //   static int[,] playField =
    //    {
    //        {1,2,3}, {4,5,6}, {7,8,9}
    //    };
    //    static void Main(string[] args)
    //    {
    //       Console.WriteLine("Please type y to start the game");

    //        string startinput = Console.ReadLine();
    //        SetField();

    //        if (startinput == "y")
    //        {
    //            playerOne();
    //        }






    //    }



    //    public static void playerOne()
    //    {
    //        Console.WriteLine("player 1 please choose number :: ");
    //        string input = Console.ReadLine(); 
    //        try
    //        {
    //            int selection = int.Parse(input);
    //            int playeroneinput = selection;
    //            for (int i = 0, j = 0; i < 3; i++, j++)
    //            {
    //                if (playField[i,j] == playeroneinput)
    //                {
    //                    Console.WriteLine("value found");
    //                    SetValue(i, j, 1);
    //                    playerTwo();
    //                    break;
    //                }
    //            }

    //        }
    //        catch(FormatException) 
    //        {
    //            Console.WriteLine(" Invalid entry try again!");
    //            playerOne();
    //           ;

    //        }
    //    }
    //    public static void playerTwo()
    //    {
    //        Console.WriteLine("player 2 please choose number :: ");
    //        string input = Console.ReadLine();
    //        try
    //        {
    //            int selection = int.Parse(input);
    //            int playertwoinput = selection;
    //            for (int i = 0, j = 0; i < 3; i++, j++)
    //            {
    //                if (playField[i, j] == playertwoinput)
    //                {
    //                    Console.WriteLine("value found");
    //                    SetValue(i, j, 1);
    //                    playerOne();
    //                    break;
    //                }
    //            }

    //        }
    //        catch (FormatException)
    //        {
    //            Console.WriteLine(" Invalid entry try again!");
    //            playerTwo();
    //            ;

    //        }
    //    }
    //    public static void SetValue(int i , int j ,int player)
    //    {   if (player == 1)
    //        {
    //          playField[i, j] = 0; 
    //        }else{
    //          playField[i, j] = 11;
    //        }

    //        Console.WriteLine("value Changed at {0} :: {1}",i,j);
    //        Console.WriteLine("   |   |   ");
    //        Console.WriteLine(" {0} | {1} | {2}", playField[0, 0], playField[0, 1], playField[0, 2]);
    //        Console.WriteLine("___|___|___");
    //        Console.WriteLine("   |   |   ");
    //        Console.WriteLine(" {0} | {1} | {2}", playField[1, 0], playField[1, 1], playField[1, 2]);
    //        Console.WriteLine("___|___|___");
    //        Console.WriteLine("   |   |   ");
    //        Console.WriteLine(" {0} | {1} | {2}", playField[2, 0], playField[2, 1], playField[2, 2]);
    //        Console.WriteLine("   |   |   ");

    //    }
    //    public static void SetField()

    //    {

    //        Console.WriteLine("   |   |   ");
    //        Console.WriteLine(" {0} | {1} | {2}", playField[0,0], playField[0, 1], playField[0, 2]);
    //        Console.WriteLine("___|___|___");
    //        Console.WriteLine("   |   |   ");
    //        Console.WriteLine(" {0} | {1} | {2}", playField[1, 0], playField[1, 1], playField[1,2]);
    //        Console.WriteLine("___|___|___");
    //        Console.WriteLine("   |   |   ");
    //        Console.WriteLine(" {0} | {1} | {2}", playField[2, 0], playField[2, 1], playField[2, 2]);
    //        Console.WriteLine("   |   |   ");
    //    }


    //}

    internal class Program
    {
        static char[,] playField =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
        
        static int turns = 0;
        static void Main(string[] args)
        {
           
           
            int player = 2; //player1 start
            int input = 0;
            bool inputCorrect = true;

            
            // Run code as long as the program runs 
            do
            {
              
               
                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player,input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player,input);
                }
               
                SetField();
                #region
                // check winning condition
                char[] playerChars = { 'X', 'O' };


                foreach(char playerChar in playerChars )
                    if (((playField[0,0] == playerChar) && (playField[0,1] == playerChar) && (playField[0,2] == playerChar))
                        || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                        || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                        || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[2, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[0, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))

                        )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\n player 2 has won");
                        }
                        else
                        {
                            Console.WriteLine("\n player 1 has won");
                        }

                        // to do reseat Field 
                        Console.WriteLine("         please press  any key to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }else if ( turns == 10)
                    {
                        Console.WriteLine( " \n draw");
                        Console.WriteLine("        Please press any key to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                #endregion
                #region
                //Test if field is already taken
                do
                {

                    Console.Write("\n      Player {0} :: Choose Your Field :: >>>", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number!");
                    }

                    if ((input == 1) && (playField[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (playField[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (playField[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (playField[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (playField[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (playField[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (playField[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (playField[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 2) && (playField[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n Incorrect Input! Please use another field!");
                        inputCorrect = false;
                    }

                } while (!inputCorrect);
                #endregion

            } while (true);



        }

        public static void ResetField() 
        {
            char[,] playFieldinit = 
          {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
            playField = playFieldinit;
            SetField();
            turns = 0;
        }
        public static void SetField()
        {
            Console.WriteLine("      ============TicTacToe============");
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("      --------------------------------");
            Console.WriteLine("      |                              |");
            Console.WriteLine("      |                              |");
            Console.WriteLine("      |            |    |            |");
            Console.WriteLine("      |          {0} |  {1} |  {2}         |", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("      |        ____|____|____        |");
            Console.WriteLine("      |            |    |            |");
            Console.WriteLine("      |          {0} |  {1} |  {2}         |", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("      |        ____|____|____        |");
            Console.WriteLine("      |            |    |            |");
            Console.WriteLine("      |          {0} |  {1} |  {2}         |", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("      |            |    |            |");
            Console.WriteLine("      |                              |");
            Console.WriteLine("      |                              |");
            Console.WriteLine("      --------------------------------");
            turns++;
        }

        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';

            if (player == 1)
                playerSign = 'X';
            else if (player == 2)
                playerSign = 'O';

            switch (input)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;

            }
        }
    }
}
