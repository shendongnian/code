    [Serializable]
    [XmlRoot(ElementName = "PARM")]
    public class ParmInfo
    {
    	private string _ParmName;
    	private string _ParmVal;
    	private bool _UsingAttr = false;
    
    	[XmlElement("KEY", IsNullable = true)]
    	public string ParmName
    	{
    		get
    		{
    			return _ParmName;
    		}
    		set
    		{
    			if(!string.IsNullOrEmpty(value))
    			{
    				_ParmName = value;
    				_UsingAttr = false;
    			}
    		}
    	}
    	
    	[XmlElement("VALUE", IsNullable = true)]
    	public string ParmVal
    	{
    		get
    		{
    			return _ParmVal;
    		}
    		set
    		{
    			if (!string.IsNullOrEmpty(value))
    			{
    				_ParmVal = value;
    			}
    		}
    	}
    
    	[XmlAttribute("KEY")]
    	public string ParmNameAttr
    	{
    		get
    		{
    			return _ParmName;
    		}
    		set
    		{
    			if (!string.IsNullOrEmpty(value))
    			{
    				_ParmName = value;
    				_UsingAttr = true;
    			}
    		}
    	}
    
    	[XmlAttribute("VALUE")]
    	public string ParmValueAttr
    	{
    		get
    		{
    			return _ParmVal;
    		}
    		set
    		{
    			if (!string.IsNullOrEmpty(value))
    			{
    				_ParmVal = value;
    			}
    		}
    	}
    
    
    	public ParmInfo()
    	{
    
    	}
    
    	public ParmInfo(string inpParmName, string inpParmVal)
    	{
    		ParmName = inpParmName;
    		_ParmVal = inpParmVal;
    	}
    }
