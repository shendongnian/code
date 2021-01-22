        public class Singleton<T>
        {
        	private static string _value;
        	public string Value
        	{
        		get
        		{
        			return _value;
        		}
        		set
        		{
        			_value = value;
        		}
        	}
        }
        public class At<T>
        {
        	public static Singleton<T> field = new Singleton<T>();
        }
        
        public class Bt : At<Bt>
        {
        }
        
        public class Ct : At<Ct>
        {
        }
    ...
        Bt.field.Value = "bt";
        Ct.field.Value = "ct";
