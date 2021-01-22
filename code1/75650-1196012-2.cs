    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            List<Action> actions = new List<Action>();
            for (int i=0; i < 10; i++)
            {
                actions.Add(delegate { Console.WriteLine(i); });
            }
                
            foreach (Action action in actions)
            {
                action();
            }
        }
    }
