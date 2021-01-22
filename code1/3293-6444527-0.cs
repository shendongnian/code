    public class DefaultValuesTest
    {    
    	public DefaultValuesTest()
    	{    			
    		foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
    		{
    			DefaultValueAttribute myAttribute = (DefaultValueAttribute)property.Attributes[typeof(DefaultValueAttribute)];
    
    			if (myAttribute != null)
    			{
    				property.SetValue(this, myAttribute.Value);
    			}
    		}
    	}
    
        public void DoTest()
    	{
    		var db = DefaultValueBool;
    		var ds = DefaultValueString;
    		var di = DefaultValueInt;
    	}
    
    
    	[System.ComponentModel.DefaultValue(true)]
    	public bool DefaultValueBool { get; set; }
    
    	[System.ComponentModel.DefaultValue("Good")]
    	public string DefaultValueString { get; set; }
    
    	[System.ComponentModel.DefaultValue(27)]
    	public int DefaultValueInt { get; set; }
    }
