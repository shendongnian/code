    public enum SchadstofklasseStrings
    {
        foo = 0,
        bar = 1,
        foobar = 2
    }
    public int Schadstoffklasse { get; set; }
    public string SchadstoffklasseToString { 
    {
        get
        {
            var stringValue = (SchadstofklasseStrings) Schadstoffklasse;
            return stringValue.ToString();
         }
    }
