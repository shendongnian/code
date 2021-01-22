    public DateTime DateField { get; set; }
    // a read only string 
    public String DateFieldString { 
        get { return DateField.ToString(/* your format */); } 
    }
