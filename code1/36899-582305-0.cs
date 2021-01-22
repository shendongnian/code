    public class DescriptiveEnum<T> where T: struct
    {
    	private static readonly Dictionary<T,string> descriptions 
            = new Dictionary<T,string>();
    	
    	static DescriptiveEnum()
    	{
            foreach (FieldInfo field in
                typeof(T).GetFields(BindingFlags.Static 
    		    | BindingFlags.GetField | BindingFlags.Public))
            {
    		descriptions.Add((T)field.GetRawConstantValue(),
    		    LookupName(field));			
            }
    	}
    	
    	public readonly T Value;
    		
    	public DescriptiveEnum(T value)
    	{
    		this.Value = value;		
    	}
    	
    	public override string ToString()
    	{
            string s;
            if (!descriptions.TryGetValue(this.Value, out s))
    	    {			
    		// fall back for non declared fields
    		s = this.Value.ToString();	
    		descriptions[this.Value] = s;
    	    }
    	    return s;
    	}
    	
        private static string LookupName(FieldInfo field)        
        {
            object[] all = field.GetCustomAttributes(
                 typeof(DescriptionAttribute), false);
            if (all.Length == 0)
                return field.Name; // fall back
            else
                return ((DescriptionAttribute)all[0])
                    .Description; // only one needed
        }	
    	
    	public static BindingList<DescriptiveEnum<T>> Make(
            IEnumerable<T> source)
    	{
            var list = new BindingList<DescriptiveEnum<T>>();
            foreach (var x in source)
    		list.Add(new DescriptiveEnum<T>(x));
    	    return list;
    	}
    }
