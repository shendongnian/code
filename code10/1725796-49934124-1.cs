    public static void Main(string[] args
    {                 
           string test_1= "Text 123 and more Text THIS IS MORE TEXT";
           string test_2 = @"(\b[^\Wa-z0-9_]+\b)";
           MatchCollection regCol = Regex.Matches(test_1, test_2);
            foreach(var text in regCol )
            {
               Console.WriteLine(text);
            }      
    }
