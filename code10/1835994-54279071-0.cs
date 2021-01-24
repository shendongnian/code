    void Main()
    {
    	var Kaefer = new PKW("VW", "Käfer", "K-GS-01", 1965, 9999, 1000, 30, Schadstoffklassen.Bar);
    	Console.WriteLine(Enum.GetName(typeof(Schadstoffklassen), Kaefer.Schadstoffklasse));
    	// Output: Bar
    }
    
    public class PKW
    {
    	private Schadstoffklassen schadstoffklasse;
    
    	public PKW(string v1, string v2, string v3, int v4, int v5, int v6, int v7, Schadstoffklassen _schadstoffklasse) {
    		schadstoffklasse = _schadstoffklasse;
    	}
    
    	public Schadstoffklassen Schadstoffklasse
    	{
    		get { return schadstoffklasse; }
    		set { schadstoffklasse = value; }
    	}
    }
    
    public enum Schadstoffklassen {
    	Foo = 0,
    	Bar = 1,
    	FooBar = 2
    }
