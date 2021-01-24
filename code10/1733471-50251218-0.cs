    public static void Main()
    	{
    	  Dictionary<DateTime, List<string>> Sample = new Dictionary<DateTime, List<string>>();
        Sample.Add( DateTime.Parse("5/8/2018 11:18:00 AM"), new List<string>());
        Sample.Add( DateTime.Parse("5/8/2018 11:17:46 AM"), new List<string>());
        Sample.Add( DateTime.Parse("2/27/2010 1:06:49 PM"), new List<string>());
        Sample.Add( DateTime.Parse("5/8/2018 11:18:08 AM"), new List<string>());	
        DateTime date = DateTime.Parse("2/27/2010 1:06:49 PM");
    foreach (KeyValuePair<DateTime, List<string>> k in Sample)
    {
       if (date.Equals(k.Key))
       {
          Console.WriteLine("Yes");
       }
       else {
          Console.WriteLine("No");
         }
       }
     }    	
