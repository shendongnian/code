    public class SectionSchoool : ConfigurationSection
    {
        public Schoool Content { get; set; }
    
    	protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
    	{
            var serializer = new XmlSerializer(typeof(Schoool)); // works in     4.0
            // var serializer = new XmlSerializer(type, null, null, null, null); // works in 4.5.1
            Content = (Schoool)serializer.Deserialize(reader);
    	}
        public static Schoool Load()
    	{
            var section = ConfigurationManager.GetSection("Schoool") as SectionSchoool;
        
    		if (section == null)
    			return null;
    
    		return section.Content;
    	}
    }
