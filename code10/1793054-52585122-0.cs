     [XmlRoot(ElementName="post")]
    	public class Post {
    		[XmlAttribute(AttributeName="id")]
    		public string Id { get; set; }
    		[XmlAttribute(AttributeName="reblogged-from-name")]
    		public string Rebloggedfromname { get; set; }
    	}
    
    	[XmlRoot(ElementName="posts")]
    	public class Posts {
    		[XmlElement(ElementName="post")]
    		public Post Post { get; set; }
    	}
