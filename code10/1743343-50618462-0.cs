       public static AskBool(string question) {
         while (true) {
           // If we have a question to ask (the question is not empty one)...
           if (string.IsNotNullOrWhiteSpace(question)) 
             Console.WriteLine(question); // ... ask it
           // Trim: let be nice and trim out leading and trailing white spaces
           string input = Console.ReadLine().Trim();
           if (string.Equals("y", StringComparison.OrdinalIgnoreCase) || 
               string.Equals("yes", StringComparison.OrdinalIgnoreCase))
             return true;
           else if (string.Equals("n", StringComparison.OrdinalIgnoreCase) || 
                    string.Equals("no", StringComparison.OrdinalIgnoreCase))
             return false;
         } 
       } 
