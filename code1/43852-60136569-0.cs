    DateTime? first = new DateTime(1992,02,02,20,50,1);
    DateTime? second = new DateTime(1992, 02, 02, 20, 50, 2);
        
    if (first.Value.Date.Equals(second.Value.Date))
    {
        Console.WriteLine("Equal");
    }
