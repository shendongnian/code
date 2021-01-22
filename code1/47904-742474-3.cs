    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main()
        {
            List<Action> actions = new List<Action>();
            
            for (int i=0; i < 5; i++)
            {
                OuterScope outer = new OuterScope();
                outer.copyOfI = i;
                
                for (int j=0; j < 5; j++)
                {
                    InnerScope inner = new InnerScope();
                    inner.outer = outer;
                    inner.copyOfJ = j;
                    
                    actions.Add(inner.Action);
                }
            }
            
            foreach (Action action in actions)
            {
                action();
            }        
        }
        
        class OuterScope
        {
            public int copyOfI;
        }
        
        class InnerScope
        {
            public int copyOfJ;
            public OuterScope outer;
            
            public void Action()
            {
                Console.WriteLine("{0} {1}", outer.copyOfI, copyOfJ);
            }
        }
    }
