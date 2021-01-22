    // the most beloved extension method for me is Pipe:
    <%= variable.Pipe(x => this.SomeFunction(x)).Pipe(y =>
    {
        ...;
        return this.SomeOtherFunction(y);
    }) %>
    
    var d = 28.December(2009); // some extension methods for creating DateTime
    DateTime justDatePart = d.JustDate();
    TimeSpan justTimePart = d.JustTime();
    var nextTime = d.Add(5.Hours());
    
    using(StreamReader reader = new StreamReader("lines-of-data-file-for-example")) {
        ...
        // for reading streams line by line and usable in LINQ
        var query = from line in reader.Lines(); 
                    where line.Contains(_today)
                    select new { Parts = PartsOf(line), Time = _now };
    }
    
    500.Sleep();
    
    XmlSerialize and XmlDeserialize
    
    IsNull and IsNotNull
    
    IfTrue, IfFalse and Iff:
    true.IfTrue(() => Console.WriteLine("it is true then!");
    
    IfNull and IfNotNull
