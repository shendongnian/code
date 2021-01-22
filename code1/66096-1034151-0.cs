    public class Gender
    {
    	private static readonly Dictionary<string, Gender> _items = new Dictionary<string, Gender>();
    
    	public static readonly Gender Male = new Gender("M", "he", age => age >= 14);
    	public static readonly Gender Female = new Gender("F", "she", age => age >= 13);
    	public static readonly Gender Unknown = new Gender("U", "he/she", age => null);
    
    	public string DatabaseKey { get; private set; }
    	public string Pronoun { get; private set; }
    	public Func<int, bool?> CanGetMarriedInTexas { get; set; }
    
    	private Gender(string databaseKey, string pronoun, Func<int,bool?> canGetMarriedInTexas)
    	{
    		DatabaseKey = databaseKey;
    		Pronoun = pronoun;
    		CanGetMarriedInTexas = canGetMarriedInTexas;
    		_items.Add(databaseKey, this);
    	}
    
    	public static Gender GetForDatabaseKey(string databaseKey)
    	{
    		if (databaseKey == null)
    		{
    			return Unknown;
    		}
    		Gender gender;
    		if (!_items.TryGetValue(databaseKey, out gender))
    		{
    			return Unknown;
    		}
    		return gender;
    	}
    
    	public IEnumerable<Gender> All()
    	{
    		return _items.Values;
    	}
    }
