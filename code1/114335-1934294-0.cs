    public class GroupBridge
    {
       [XmlAttribute (Namespace = "http://www.cpandl.com")]
       public string GroupName;
    
       [XmlAttribute(DataType = "base64Binary")]
       public Byte [] GroupNumber;
    
       [XmlAttribute(DataType = "date", AttributeName = "CreationDate")]
       public DateTime Today;
       
       public Group AsOriginal()
       {
    	Group g = new Group();
    	g.GroupName = this.GroupName;
    	g.GroupNumber = this.GroupNumber;
    	g.Today = this.Today;
    
    	return g;
       }
    }
    
    public class Group
    {
       public string GroupName;
       public Byte [] GroupNumber;
       public DateTime Today;
    }
