    public class Rootobject
    {
        public Room room { get; set; }
        public Dictionary<string, Set> sets { get; set; }
    }
    
    public class Set
    {
    	public int _type { get; set; }
    	public object css { get; set; }
    	public object description { get; set; }
    	public Emoticon[] emoticons { get; set; }
    	public object icon { get; set; }
    	public int id { get; set; }
    	public string title { get; set; }
    }
