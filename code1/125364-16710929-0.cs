    [System.Serializable]
    [System.Xml.Serialization.XmlInclude(typeof(Entity))]
    public class Map
    {
    	internal string MapName;
    	internal string MapDescription;
    	internal string MapAuthor;
    	public List<Entity> Entities = new List<Entity>();
    }
