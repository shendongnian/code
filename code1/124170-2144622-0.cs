     public int X {get;set;}
     public string Y { get; set; }
     // repeat as necessary
  
     public settings()
     {
        this.X = defaultForX;
        this.Y = defaultForY;
        // repeat ...
     }
     public void Parse(Uri uri)
     {
        // parse values from query string.
        // if you need to distinguish from default vs. specified, add an appropriate property
     }
