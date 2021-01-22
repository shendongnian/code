    private int      PropInt    { get; set; }
    private DateTime PropDate   { get; set; }
    private string   propString { get; set; }
    
    propString = ""; // propString != null
    
    WriteLine(PropInt.GetType().ToString());    // Result : System.Int32
    WriteLine(PropDate.GetType().ToString());   // Result : System.DateTime
    WriteLine(propString.GetType().ToString()); // Result : System.String
