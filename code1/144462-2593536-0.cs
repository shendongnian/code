    var groups = list.GroupBy(dateTime => dateTime.Date);
    foreach (var group in groups)
    {
        Console.WriteLine("{0}:", group.Key);
        foreach(var dateTime in group)
        {
            Console.WriteLine("  {0}", dateTime.TimeOfDay);
        }
    }
