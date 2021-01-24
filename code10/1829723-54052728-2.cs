    using System;
    
    namespace SimpleGame
    {
        class Program
        {
            public delegate int SquareDelegate(int number);
    
            static void Main(string[] args)
            {
                string appName = "Rock, Paper, Scissors";
                string appVersion = "1.0.0";
                string author = "Rhys Keown";
    
                Console.WriteLine("{0}, Version {1}, Made By {2}", appName, appVersion, author);
                Console.WriteLine();
    
                Console.WriteLine("Please press any key to begin the game!");
                Console.ReadKey();
    
                // Ask for the user to input either Rock, Paper, Scissors
                Console.WriteLine("Please input either Rock, Paper or Scissors");
                string userOpt = Console.ReadLine();
    
                // Random option completed by the computer.
                string[] rpsOpt = new string[] { "Rock", "Paper", "Scissors" };
                Console.WriteLine("The computer has chosen:");
                
                // Computer Chosen value - Stored to 'b'
                string b = rpsOpt[new Random().Next(0, rpsOpt.Length)];
    
                //string finalOpt = Console.ReadLine();
    
                // If the selection of the user beats the computer then You Win! 
                // is printed and you are asked if you want to have another game.
                string a = userOpt;
    
                if (b == "Rock" && a == "Rock")
                {
                    Console.WriteLine("You have drawn");
                }
    
                else if (b == "Paper" && a == "Paper")
                {
                    Console.WriteLine("You have drawn");
                }
    
                else if (b == "Scissors" && a == "Scissors")
                {
                    Console.WriteLine("You have drawn");
                }
    
                else if (b == "Rock" && a == "Scissors")
                {
                    Console.WriteLine("You have lost");
                }
    
                else if (b == "Rock" && a == "Paper")
                {
                    Console.WriteLine("You have won!!");
                }
    
                else if (b == "Scissors" && a == "Rock")
                {
                    Console.WriteLine("You have won!!");
                }
    
                else if (b == "Scissors" && a == "Paper")
                {
                    Console.WriteLine("You have lost");
                }
    
                else if (b == "Paper" && a == "Scissors")
                {
                    Console.WriteLine("You have won!!");
                }
    
                else if (b == "Paper" && a == "Rock")
                {
                    Console.WriteLine("You have lost");
                }
                else (b == "Paper" && a == "Rock")
                {
                    Console.WriteLine("Something Wrong When Computing results..");
                }
    
                Console.ReadKey();
            }
        }
    }
