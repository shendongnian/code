    public partial class Rootobject
    {
    	public string Company { get; set; }
    	public Dictionary<string, Package> Packages { get; set; }
    }
    
    public partial class Package
    {
    	public string Code { get; set; }
    	public string Name { get; set; }
    	public long Price { get; set; }
    }
