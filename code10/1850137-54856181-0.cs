    void Number() 
    {
        //Code...
    
        While(isvalid); 
        {
             Console.WriteLine("want to play again o/n "); 
             play = Console.Read();
    
              if(!string.IsNullOrEmpty(play) && play.Equals('o', CultureInfo.InvariantCulture) 
              {
                  /////// Some code you want to execute;
              }
              else 
              {
                   ////// Some code you want to execute if user enters anything other than 'o'.
    
                    ////// If you want to stop loop, set isValid = false; OR use break statement
              }
        }
    }
