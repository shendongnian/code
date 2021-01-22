    private string _date; // Private variable to store XML string
    
    // Property that exposes date. Specifying the type forces
    // the serializer to return the value as a string.
    [XmlElement("date", Type = typeof(string))]
    public object Date {
        // Return a DateTime object
        get { return Convert.ToDateTime(_loanDate); }
        set { _loanDate = (string)value; } 
    }
