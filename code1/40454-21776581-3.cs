    [DataMember, XmlIgnore]
    public TimeSpan? MyTimeoutValue { get; set; }
    [DataMember]
    public string MyTimeout
    {
        get 
        {
            if (MyTimeoutValue != null)
                return MyTimeoutValue.ToString();
            return null;
        }
        set 
        {
            TimeSpan outValue;
            if (TimeSpan.TryParse(value, out outValue))
                MyTimeoutValue = outValue;
            else
                MyTimeoutValue = null;
        }
    }
