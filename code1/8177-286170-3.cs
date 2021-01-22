    namespace outreftry
    {
        class outref
        {
            static void Main(string[] args)
            {
                yyy a = new yyy(); ;
    
                int i = 0;
    
                a.abc(ref i);
    
                System.Console.WriteLine(i);
            }
        }
        class yyy
        {
    
            public void abc(ref int i)
            {
                System.Console.WriteLine(i);
                i = 10;
    
            }
    
        }
    }
