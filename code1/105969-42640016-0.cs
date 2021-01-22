    var myDateUtc = DateTime.SpecifyKind(DateTime.Parse("Tue, 1 Jan 2008 00:00:00"), DateTimeKind.Utc);
                
    if (myDateUtc.Kind == DateTimeKind.Utc)
    {
         Console.WriteLine("Yes. I am UTC!");
    }
