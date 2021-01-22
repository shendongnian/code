    namespace EventTest
    {
        class Program
        {
            static object _Lock = new object();
            static void Main(string[] args)
            {
                Timer t = new Timer(2000);
                t.Enabled = true;
                t.Elapsed += new ElapsedEventHandler(TimerHandler);
                for (int i = 0; i < 10000; i++)
                {
                    for (int j = 0; j < 100000000; j++) ;
                    lock (_Lock)
                        Console.WriteLine(i);
                }
            }
            public static void TimerHandler(object source, EventArgs e)
            {
                lock (_Lock)
                {
                    Console.WriteLine("Event started");
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 100000000; j++) ;
                        Console.WriteLine("Event "+i);
                    }
                    Console.WriteLine("Event finished");
                }
            }
        }
    }
