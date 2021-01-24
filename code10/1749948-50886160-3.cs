    void Main()
    {
    	var o1 = new C { Interesting = "Whatever", NotSoInterresting = "Blah.." };
    	var o2 = new C { Interesting = "Whatever", NotSoInterresting = "Blah-blah.." };	
    	
    	(o1 == o2).Dump("o1 == o2"); // False
    	(o2 == o1).Dump("o2 == o1"); // False
    	
    	var o3 = o1.Clone();
    	(o3 == o1).Dump("o3 == o1"); // True
    	(object.ReferenceEquals(o1, o3)).Dump("R(o3) == R(o2)"); // False
    
    	o3.NotSoInterresting = "Changed!";
    	(o1 == o3).Dump("o1 == C(o3)"); // True
    
    	o3.Interesting = "Changed!";
    	(o1 == o3).Dump("o1 == C(o3)"); // False
    }
    
    [AttributeUsage(AttributeTargets.Field)]
    public class IncludeAttribute : Attribute { }
    
    public static class ObjectExtensions
    {
    	public static int GetHash(this object obj) => obj?.GetHashCode() ?? 1;
    	
    	public static int CalculateHashFromFields(this object obj)
    	{
    		var fields = obj.GetType()
    			.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly /*or not*/)
    			.Where(f => f.CustomAttributes.Any(x => x.AttributeType.Equals(typeof(IncludeAttribute))));
    		
    		var result = 1;
    
    		unchecked
    		{
    			foreach(var f in fields) result *= f.GetValue(obj).GetHash();
    		}
    		
    		return result;
    	}
    }
    
    public partial class C
    {
    	[Include]
    	private int id;
    	public int Id { get => id; private set { id = value; UpdateHash(); } }
    
    	[Include]
    	private string interesting;
    	public string Interesting { get => interesting; set { interesting = value; UpdateHash(); } }
    
    	public string NotSoInterresting { get; set; }
    }
    
    public partial class C: IEquatable<C>
    {
    	public C Clone() => new C { Id = this.Id, Interesting = this.Interesting, NotSoInterresting = this.NotSoInterresting };
    	
    	private static int _id = 1; // Some persistence is required instead
    	
    	public C()
    	{
    		Id = _id++;
    	}
    	
    	private int hash;
    	
    	private void UpdateHash() => hash = this.CalculateHashFromFields();
    
    	public override bool Equals(object obj)
    	{
    		return Equals(obj as C);
    	}
    
    	public bool Equals(C other) => this.hash == other.hash;
    
    	public override int GetHashCode() => hash;
    	
    	public static bool operator ==(C obj1, C obj2) => obj1.Equals(obj2);
    	
    	public static bool operator !=(C obj1, C obj2) => !obj1.Equals(obj2);
    }
