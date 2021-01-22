    public class c 
    {    	
    	[XmlIgnore]
    	private Type t;
    	[XmlIgnore]
    	public Type T {
    		get { return t; }
    		set { 
    				t = value;
    				tName = value.AssemblyQualifiedName;
    			}
    	}
    		
    	public string tName{
    		get { return t.AssemblyQualifiedName; }
    		set { t = Type.GetType(value);}
    	}
    }
