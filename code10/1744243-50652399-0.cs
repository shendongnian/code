    void Main()
    {
    	Dictionary<string, bool> limbRepair = new Dictionary<string, bool>
    	{
    		{ "Head", false },
    		{ "LeftArm", false },
    		{ "RightArm", false },
            // Etc.
    	};
    		
    	MechDefinition mechDef = new MechDefinition();
    	List<Limb> limbs = new List<Limb>();
    	foreach (KeyValuePair<string, bool> limbsToRepair in limbRepair.Where(x => !x.Value))
    	{
    		Limb limb = (Limb)mechDef.GetPropValue(limbsToRepair.Key);
    		limb.CurrentInternalStructure = 9001;
    	}
    }
    
    public class MechDefinition
    {
    	public MechDefinition()
    	{
    		Head = new Limb
    		{
    			Id = Guid.NewGuid(),
    			DateAdded = DateTime.Parse("2018-01-01"),
    			Name = "Main Head",
    			CurrentInternalStructure = 8675309
    		};
    	}
    	public Guid Id { get; set; }
    	public string Name { get; set; }
    	public int CurrentInternalStructure { get; set; }
    	public Limb Head { get; set; } = new Limb();
    	public Limb LeftArm { get; set; } = new Limb();
    	public Limb RightArm { get; set; } = new Limb();
    	// etc...
    }
    
    public class Limb
    {
    	public Guid Id { get; set; }
    	public string Name { get; set; }
    	public DateTime DateAdded { get; set; }
    	public int CurrentInternalStructure { get; set; }
    	public bool IsDisabled { get; set; }
    }
    
    public static class ReflectionHelpers
    {
    	public static object GetPropValue(this object obj, string name)
    	{
    		foreach (string part in name.Split('.'))
    		{
    			if (obj == null) { return null; }
    
    			Type type = obj.GetType();
    			PropertyInfo info = type.GetProperty(part);
    			if (info == null) { return null; }
    
    			obj = info.GetValue(obj, null);
    		}
    		return obj;
    	}
    	
    	public static object SetPropValue(this object obj, string name, object value)
    	{
    		foreach (string part in name.Split('.'))
    		{
    			if (obj == null) { throw new ObjectNotFoundException(); }
    			
    			Type type = obj.GetType();
    			PropertyInfo info = type.GetProperty(part);
    			if (info == null) { return null; }
    			obj = info.GetValue(obj, null);
    
    			info.SetValue(obj, value);
    		}
    		return obj;
    	}
    
    	public static T GetPropValue<T>(this object obj, string name)
    	{
    		object retval = GetPropValue(obj, name);
    		if (retval == null) { return default(T); }
    
    		// throws InvalidCastException if types are incompatible
    		return (T)retval;
    	}
    }
