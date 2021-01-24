    static void Main(string[] args)
    {
        var culture = new CultureInfo("en-US", false);
        Dictionary<DateTime, List<string>> Sample = new Dictionary<DateTime, List<string>>();
                
        Sample.Add( DateTime.Parse("5/8/2018 11:18:00 AM", culture), new List<string>());
        Sample.Add( DateTime.Parse("5/8/2018 11:17:46 AM", culture), new List<string>());
        Sample.Add( DateTime.Parse("2/27/2010 1:06:49 PM", culture), new List<string>());
        Sample.Add( DateTime.Parse("5/8/2018 11:18:08 AM", culture), new List<string>());
    
        DateTime date = DateTime.Parse("2/27/2010 1:06:49 PM", culture);
        foreach (KeyValuePair<DateTime, List<string>> k in Sample)
        {
            if (date.Equals(k.Key))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
