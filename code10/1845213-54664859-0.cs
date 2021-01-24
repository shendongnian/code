public static void Main(string[] args)
        {
              int i = 0;
           while(condition)
           {
             .........
             .........
           // a block without condition                    
            {
                i = 6;
                Console.WriteLine("Inside Block :" +i);
            }
          }
        }               
    }
Since your variable `i` is defined on method level, it doesn't have any significant impact on your code.
Let's say you defined a variable inside that scope, and tried accessing it outside, it would generate an error since any variable defined inside a scope has its limit to the boundaries of scope.
For Example. 
public static void Main(string[] args)
        {
              int i = 0;
           while(condition)
           {
             .........
             .........
           // a block without condition                    
            {
                int j = 44;
                i = 6;
                Console.WriteLine("Inside Block :" +i);
            }
          }
          Console.WriteLine(j); // <------------------ This would generate error.
        }               
    }
