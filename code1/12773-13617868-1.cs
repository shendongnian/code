    namespace ConsoleApplication1
    {    
        class Program 
        {
            public event EventHandler ss;
            Program()
            {
                if (null != ss)
                {
                    ss(this, EventArgs.Empty) ;
                    
                }
            }
            static void Main(string[] args)
            {
                new Program();
            }
        }
    }
