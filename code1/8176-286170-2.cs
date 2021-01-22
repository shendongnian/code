    namespace outreftry
    {
        class outref
        {
            static void Main(string[] args)
            {
                yyy a = new yyy(); ;
    
                // u can try giving int i=100 but is useless as that value is not passed into
                // the method. Only variable goes into the method and gets changed its
                // value and comes out. 
                int i; 
    
                a.abc(out i);
    
                System.Console.WriteLine(i);
            }
        }
        class yyy
        {
    
            public void abc(out int i)
            {
                 
                i = 10;
    
            }
    
        }
    }
