    private static TextWriter tw { get; set; }
    static void Main(string[] args)
    {
        using (tw = new StreamWriter("TextFile1.txt"))
        {
            Timer t = new Timer(1000);
            t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            t.Start();
            Console.Read();
            t.Stop();
            tw.Close();
        }
    static void OnTimedEvent(object sender, ElapsedEventArgs args)
    {
        // write a line of text to the file
        tw.WriteLine(DateTime.Now.ToString());
    }
