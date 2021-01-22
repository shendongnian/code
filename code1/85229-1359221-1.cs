    internal class Example
    {
            private static object obj;
    
            static Example()
            {
                    obj = new object();
                    return;
            }
    
            public Example()
            {
                    base..ctor();
                    return;
            }
    
            private static int Bar()
            {
                    int CS$1$0000;
                    object CS$2$0001;
                    Monitor.Enter(CS$2$0001 = obj);
            Label_000E:
                    try
                    {
                            Console.WriteLine("Bar");
                            goto Label_0025;
                    }
                    finally
                    {
                    Label_001D:
                            Monitor.Exit(CS$2$0001);
                    }
            Label_0025:
                    CS$1$0000 = 2;
            Label_002A:
                    return CS$1$0000;
            }
    
            private static int Foo()
            {
                    int CS$1$0000;
                    object CS$2$0001;
                    Monitor.Enter(CS$2$0001 = obj);
            Label_000E:
                    try
                    {
                            Console.WriteLine("Foo");
                            CS$1$0000 = 1;
                            goto Label_0026;
                    }
                    finally
                    {
                    Label_001E:
                            Monitor.Exit(CS$2$0001);
                    }
            Label_0026:
                    return CS$1$0000;
            }
    }
