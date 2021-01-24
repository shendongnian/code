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
    }
    
    public abstract class EquatableBase : IEquatable<EquatableBase>
    {
    	private static FieldInfo[] fields = null;
    	
    	private void PrepareFields()
    	{
    		fields = this.GetType()
    			.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly /*or not*/)
    			.Where(f => f.CustomAttributes.Any(x => x.AttributeType.Equals(typeof(IncludeAttribute))))
    			.ToArray();
    	}
    
    	private int CalculateHashFromProperties()
    	{
    		if (fields == null) PrepareFields();
    
    		var result = 1;
    
    		unchecked
    		{
    			foreach (var f in fields) result *= f.GetValue(this).GetHash();
    		}
    
    		return result;
    	}
    
    	private int hash;
    	
    	protected int UpdateHash() => hash = this.CalculateHashFromProperties();
    	
    	protected void InvalidateHash() => hash = 0;
    
    	public override bool Equals(object obj)
    	{
    		return Equals(obj as EquatableBase);
    	}
    
    	public bool Equals(EquatableBase other) => this.GetHashCode() == other.GetHashCode();
    
    	public override int GetHashCode() => hash == 0 ? UpdateHash() : hash;
    
    	public static bool operator ==(EquatableBase obj1, EquatableBase obj2) => obj1.Equals(obj2);
    
    	public static bool operator !=(EquatableBase obj1, EquatableBase obj2) => !obj1.Equals(obj2);
    }
    
    public partial class C: EquatableBase
    {
    	private static int _id = 1; // Some persistence is required instead
    
    	public C()
    	{
    		Id = _id++;
    	}
    
    	public C Clone() => new C { Id = this.Id, Interesting = this.Interesting, NotSoInterresting = this.NotSoInterresting };
    	
    	[Include]
    	private int id;
    	public int Id { get => id; private set { id = value; InvalidateHash(); } }
    
    	[Include]
    	private string interesting;
    	public string Interesting { get => interesting; set { interesting = value; InvalidateHash(); } }
    
    	public string NotSoInterresting { get; set; }
    }
