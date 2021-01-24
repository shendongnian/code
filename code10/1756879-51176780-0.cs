    public class RootObject
    {
    	public Data data { get; set; }
    	public DateTime latest { get; set; }
    	public int sensor_height { get; set; }
    	public string type { get; set; }
    	public int base_height { get; set; }
    	public Geom geom { get; set; }
    	public string active { get; set; }
    	public string name { get; set; }
    	public Source source { get; set; }
    }
    
    public class Data
    {
    	public Temperature Temperature { get; set; }
    	public Meta meta { get; set; }
    }
    
    public class Geom
    {
    	public float[] coordinates { get; set; }
    	public string type { get; set; }
    }
    
    public class Source
    {
    	Public string document { get; set; }
    	Public string fancy_name { get; set; }
    	Public string db_name { get; set; }
    	Public string third_party { get; set; }
    	Public string web_display_name { get; set; }
    }
    
    public class Temperature 
    {
    	public string data { get; set; }
    }
    
    public class Meta
    {
    	Public string units { get; set; }
    	Public string name { get; set; }
    	Public string theme { get; set; }
    }
