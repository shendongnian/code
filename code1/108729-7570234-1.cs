    class Program
    {
        static Timer s = new Timer();
        static int i = 0;
        static void Main(string[] args)
        {
            s.Elapsed += Restart;
            s.Start();
            Console.ReadLine();
        }
        static void Restart(object sender, ElapsedEventArgs e)
        {
            s.Dispose();
            if (i < 100)
            {
                Console.WriteLine(++i);
                s = new Timer(1);
                s.Elapsed += Restart;
                s.Start();
            }
        }
    }
