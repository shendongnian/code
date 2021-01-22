     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
     using System.IO;
     namespace Guess_Game
    {
    class Program
    {
        static void Main(string[] args)
        {
            int quantity;
            int min, max;
            int[] number = new int[10];
            Console.WriteLine("Enter the Quantity of Numbers : ");
            quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Maximum and Minimum Number t \n");
            Console.WriteLine("MIN : ");
            min = int.Parse(Console.ReadLine());
            Console.WriteLine("MAX : ");
            max = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantity; i++)
            {
                Console.WriteLine("Now, Guess the {0}Number : ", i + 1);
                number[i] = int.Parse(Console.ReadLine());
            }
            GuessGame(min, max, quantity, number);
            //if(number!= // number not equal to that number that contains in a file.. how to write it in that 
            //if condition..
        }
        static void GuessGame(int min, int max, int quantity, int[] number)
        {
            Random r = new Random();
            StreamWriter sw = new StreamWriter(@"C: Guess Game.txt");
            int[] temp = new int[quantity];
            for (int i = 0; i < quantity; i++)
            {
                temp[i] = r.Next(min, max);
                sw.WriteLine(temp[i]);
            }
            sw.Close();
            StreamReader sr = new StreamReader(@"C: Guess Game.txt");
            int trying = 3;
            int[] guess = new int[10];
            for (int i = 0; i <= quantity; i++)
                guess[i] = Convert.ToInt32(sr.ReadLine());
            for (int i = 0; i < quantity;i++ )
                for (int j = 0; j < quantity; j++)
                    if (number[j] != guess[i] )
                    {
             System.Console.WriteLine("you have wrong Answer,you have {0} try ", trying--);
                        for (int k = 0; k < quantity; k++)
                        {
                            Console.WriteLine("you {0} Number is", k+1);
                            number[k] = Convert.ToInt32(System.Console.ReadLine());
                        }
                        if(trying==0)
                        for (j = 0; j <quantity; j++)
               Console.WriteLine("Your Guess is right! the right answer is{0} ", guess[j]);
                   
                   
                    }
            for (int j = 0; j < quantity; j++)
             Console.WriteLine("Your Guess is right! the right answer is{0} ", guess[j]);
      Console.ReadLine();  } 
    }
    }
   
