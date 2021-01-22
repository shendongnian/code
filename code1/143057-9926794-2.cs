    using System;
    using System.Text.RegularExpressions;
    
    class MainClass {
    
        private static void DisplayMatches(string text,
                                           string regularExpressionString) 
        {
            Console.WriteLine("using the following regular expression: " 
                            +regularExpressionString);
            MatchCollection myMatchCollection = 
                Regex.Matches(text, regularExpressionString);
  
            foreach (Match myMatch in myMatchCollection) {
              Console.WriteLine(myMatch);
            }
        }
      
        public static void Main() 
        {
            string text ="Missisipli Kerrisdale she";
          
            Console.WriteLine("Matching words that that contain " 
                              + "two consecutive identical characters");
            DisplayMatches(text, @"\S*(.)\1\S*");
        }
    }
