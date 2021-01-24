     public Class1()
    {
    
        private static List<string> allowedChars= new List<string>(){
             "a","b","c","d"
         };
         public void Verify()
         {
              Console.WriteLine("Enter a, b, c or d:");
              string input = Console.ReadLine();
              while (!allowedChars.Contains(input))
             {
                  Console.WriteLine("Try again");       
                  Console.WriteLine("Enter a, b, c or d:");
                  input = Console.ReadLine();
              }
        }
    }
