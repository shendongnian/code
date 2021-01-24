    string s = "2018-06-29T22:10:33Z";
    DateTime t;
    if (DateTime.TryParse(s, out t))
    {
    	Console.WriteLine(t.ToShortDateString());
    }
