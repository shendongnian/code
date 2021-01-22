    // the most beloved extension method for me is Pipe:
    <%= variable.Pipe(x => this.Fun1(x)).Pipe(x =>
    {
        ...;
        return this.F2(x);
    }) %>
    
    var d = 28.December(2009); // some extension methods for creating DateTime
    d.JustDate();
    d.JustTime();
    
    StreamReader sr;
    ...
    sr.Lines(); // for reading streams line by line and usable in LINQ
    
    500.Sleep();
    
    XmlSerialize and XmlDeserialize
    
    IsNull and IsNotNull
    
    IfTrue, IfFalse and Iff:
    true.IfTrue(() => Console.WriteLine("it is true then!");
    
    IfNull and IfNotNull
