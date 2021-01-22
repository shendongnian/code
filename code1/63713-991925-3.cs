     int enterYourNumber;
     char shortLetter;
     do
     {
          try
          {
              Console.WriteLine("Please enter the integer: ");                
              enterYourNumber = Convert.ToInt32(Console.ReadLine());                
              WriteNumber(enterYourNumber); 
          }
          catch( FormatException )
          {                                        
              Console.WriteLine("Please enter an integer not a character");
          }  
          
          shortLetter = '\0';
          do
          {
              try
              {
                  Console.WriteLine("Do you still want to enter a number? Y/N");                    
                  shortLetter = Convert.ToChar(Console.ReadLine());
              }
              catch( FormatException ) 
             {
                  Console.WriteLine("Please enter a single character");
             }
          }     
          while ( shortLetter == '\0' )      
     }                
     while (shortLetter == 'y' || shortLetter == 'Y')
 
     }
            public static void WriteNumber(int wordValue)
            {
            switch (wordValue)
            {
                case 1:
                    Console.WriteLine("You have entered number one");
                    break;
                case 2:
                    Console.WriteLine("You have entered number two");
                    break;
                case 3:
                    Console.WriteLine("You have entered number three");
                    break;
                default:
                    Console.WriteLine("You have exceeded the range of number 1-3 ");
                    break;
            }
