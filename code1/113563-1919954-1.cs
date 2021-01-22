         static void Main(string[] args)
        {
            Func<int, int> NestedMethod = delegate(int x)     
            {             Console.WriteLine("In nested method. Value of x is {0}.", x);        
                return x;         
            };
            HigerOrderTest(NestedMethod)();
        }
         private static Action HigerOrderTest(Func<int, int> highFunction)
        {
              var sam = highFunction(3);
              Action DoIt =() =>
              {
                  Console.WriteLine("Output is {0}.", sam);    
              };
                 return DoIt;
        }
