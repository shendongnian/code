    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main() 
        {
            List<Action> badActions = new List<Action>();
            List<Action> goodActions = new List<Action>();
            for (int i=0; i < 10; i++)
            {
                int copy = i;
                badActions.Add(() => Console.WriteLine(i));
                goodActions.Add(() => Console.WriteLine(copy));
            }
            Console.WriteLine("Bad actions:");
            foreach (Action action in badActions)
            {
                action();
            }
            Console.WriteLine("Good actions:");
            foreach (Action action in goodActions)
            {
                action();
            }
        }
    }
