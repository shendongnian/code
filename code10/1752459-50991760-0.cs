    static void Main(string[] args)
    {
        Settings1.Default.Background = Color.Red;
        Settings1.Default.SoundFile = "ring.wav";
        Settings1.Default.Save();
        Console.WriteLine("finished");
        Console.ReadLine();
    }
