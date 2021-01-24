    namespace NameScoreTest
    {
    using System;
    using System.Collections.Generic;
    
    public static class Program
    {
        private static Dictionary<char, int> Letters = new Dictionary<char, int>(){
                {'A', 1}, {'B', 3}, {'C', 3}, {'D', 2}, {'E', 1}, {'F', 4}, {'G', 2}, {'H', 4}, {'I', 1}, {'J', 8}, {'K', 5}, {'L', 1}, {'M', 3 }, {'N', 1}, {'O', 1}, {'P', 3}, {'Q', 10 }, {'R', 1}, {'S', 1}, {'T', 1}, {'U',1}, {'V', 4}, {'W', 4}, {'X', 8}, {'Y', 4}, {'Z', 10}
            };
        private static Dictionary<char, int> occurences = new Dictionary<char, int>();
        private static char previous = ' ';
    
        static void Main(string[] args)
        {
            int score = CalculateScore("Thomas");
    
            Console.WriteLine("Score for name Thomas is " + score);
            Console.WriteLine("Press any key to exit");
    
            Console.ReadKey();            
        }
    
        public static int CalculateScore(String input)
        {
         // The score
         int score = 0;
         foreach (char c in input)
         {
            char o = Char.ToUpper(c);
            if (occurences.ContainsKey(o))
            {
               occurences[o] += 1;
               if (occurences[o] == 2)
               {
                  if (o == previous)
                  {
                   score += 3 * letters[o]; //if second letter, than previously was added normal value, thus we add triple value to get to double value for both letters
                  }
                  else
                  {
                      score += (int) Math.Ceiling(1.0 * letters[o] / 2);
                  }
               }
               else if (occurences[o] == 3)
                {
                   if (o == previous)
                   {
                      score -= (int) Math.Ceiling(1.0 * letters[o] / 2); //subtracts previously added score for the letter (half of normal value)
                      score += 4 * letters[o]; //adds double value for 2 letters, thus equals 4
                    }
                    else
                    {
                       score += 2 * letters[o];
                    }
                }
                else if (o == previous)
                {
                   score += 2 * letters[o];
                }
              }
              else
              {
                 occurences[o] = 1;
                 score += letters[o];
              }
              previous = o;
              Console.WriteLine(score + " " + o);
           }
           return score;
        }
    }
    }
