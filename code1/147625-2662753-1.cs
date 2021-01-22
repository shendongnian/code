    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int tick = System.Environment.TickCount;
                for (int i = 0; i < 1000000000; ++i)
                {
                }
                tick = System.Environment.TickCount - tick;
                Console.Write( tick.ToString() + " ms" ) ; 
            }
        }
    }
