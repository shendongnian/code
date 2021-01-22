    [XmlIgnore]
    public Nullable<DateTime> AccountExpirationDate 
    { 
    	get { return userPrincipal.AccountExpirationDate; } 
    	set { userPrincipal.AccountExpirationDate = value; } 
    }
    
    ///
    /// <summary>Used for Xml Serialization</summary>
    ///
    [XmlAttribute("AccountExpirationDate")]
    public string AccountExpirationDateString
    {
    	get
    	{
    		return AccountExpirationDate.HasValue
    			? AccountExpirationDate.ToString("yyyy/MM/dd HH:mm:ss.fff")
    			: string.Empty;
    	}
    	set
    	{
    		AccountExpirationDate =
    			!string.IsNullOrEmpty(value)
    			? DateTime.ParseExact(value, "yyyy/MM/dd HH:mm:ss.fff")
    			: null;
    	}
    }
