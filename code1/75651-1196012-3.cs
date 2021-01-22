    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            List<Action> actions = new List<Action>();
            for (int i=0; i < 10; i++)
            {
                int copy = i;
                actions.Add(delegate { Console.WriteLine(copy); });
            }
                
            foreach (Action action in actions)
            {
                action();
            }
        }
    }
