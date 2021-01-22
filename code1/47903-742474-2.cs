    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            List<Action> actions = new List<Action>();
            
            for (int i=0; i < 5; i++)
            {
                int copyOfI = i;
                
                for (int j=0; j < 5; j++)
                {
                    int copyOfJ = j;
                    
                    actions.Add(delegate
                    {
                        Console.WriteLine("{0} {1}", copyOfI, copyOfJ);
                    });
                }
            }
            
            foreach (Action action in actions)
            {
                action();
            }        
        }
    }
