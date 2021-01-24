    static void Main(string[] args)
    {
        List<string> times = new List<string>();
        times.Add("08:30");
        times.Add("10:00");
        times.Add("09:00");
        TimeSpan tot = TimeSpan.Zero;
        foreach (var time in times)
        {
            if (time.Equals("00:00") == false)
            {
                TimeSpan hourcant = TimeSpan.Parse(time);
                tot = tot + hourcant;
            }
        }
        Console.WriteLine(tot.ToString(@"hh\:mm"));
        Console.ReadLine();
    }
