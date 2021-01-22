    class Program
    {
            delegate void Action();
            static void Main(string[] args)
            {
                    List<Action> actions = new List<Action>();
    
                    DisplayClass1 displayClass1 = new DisplayClass1();
                    for (displayClass1.i = 0; displayClass1.i < 10; ++displayClass1.i )
                            actions.Add(new Action(displayClass1.Lambda));
    
                    foreach (Action a in actions)
                            a();
            }
    
            class DisplayClass1
            {
                    int i;
                    void Lambda()
                    {
                            Console.WriteLine(i);
                    }
            }
    }
