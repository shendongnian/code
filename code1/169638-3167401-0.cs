    public static void Main()
    {
        string text = "3.14";
        var timer = new Stopwatch();
        timer.Start();
        for (int i = 0; i < 10000000; i++)
        {
            double d;
            d = Convert.ToDouble(text);
            //double.TryParse(text, out d);
            //d = double.Parse(text);
        }
        timer.Stop();
        Console.WriteLine("Time=" + timer.Elapsed.ToString());
        Console.ReadLine();
    }
