    [DefaultValue("0.0.0.0")]
    public string AgentVersion
    {
    	get
    	{
    		return System.Text.RegularExpressions.Regex.IsMatch(m_version ?? String.Empty, @"\A\d+[.]\d+[.]\d+[.]\d+\z") 
    			? m_version 
    			: "0.0.0.0";
    	}
    }
    
    private string m_version;
