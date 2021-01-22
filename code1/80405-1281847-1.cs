    public static class Program
    {
        [STAThread]
        static void Main(String[] args)
        {
            TimerTask task = new TimerTask(1000);
            Console.WriteLine("Timer start.");
            task.Start();
            Console.ReadLine();
            Console.WriteLine("Timer stop.");
            task.Stop();
            Console.ReadLine();
            Console.WriteLine("Timer start.");
            task.Start();
            Console.ReadLine();
            Console.WriteLine("Timer stop.");
            task.Stop();
            Console.ReadLine();
        }
    }
