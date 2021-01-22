    class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                var x = p.Something;
                Console.ReadLine();
            }
    
            public string Something
            {
                get
                {
                    return MethodBase.GetCurrentMethod().Name;
                }
            }
        }
