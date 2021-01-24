    `
    
        public static int askInt(string question)
            {
               Int intToReturn = false;
               Console.Write(question);
               while (true)
               {
                  string ans = Console.ReadLine();
                  if (int.TryParse(and,out intToreturn))
                      break;
                  else
                      Console.Write("Only number Allowed");
               }
               return intToReturn;
            }`
