    [Serializable]
    public class MyClass
    {
    	public MyClass() { }
    
    	[XmlIgnore]
    	public string MyString { get; set; }
    	[XmlElement("MyString")]
    	public System.Xml.XmlCDataSection MyStringCDATA
    	{
    		get
    		{
    			return new System.Xml.XmlDocument().CreateCDataSection(MyString);
    		}
    		set
    		{
    			MyString = value.Value;
    		}
    	}
    }
