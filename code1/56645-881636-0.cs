    using System.Security;
    using System.Security.Permissions;
    
    public static class HashSetDelegate
    {
        public static HashSet<T> Create<T>(Func<T, T, bool> func)
        {
    	return new HashSet<T>(new FuncIEqualityComparerAdapter<T>(func));
        }
        
        private class FuncIEqualityComparerAdapter<U> : IEqualityComparer<U>
        {
    	private Func<U, U, bool> func;
    	public FuncIEqualityComparerAdapter(Func<U, U, bool> func)
    	{
    	    this.func = func;
    	}
    
    	public bool Equals(U a, U b)
    	{
    		return func(a, b);
    	}
    
    	public int GetHashCode(U obj)
    	{
    	    return 0;
    	}  
    	    
        }
    }
    
    public class HashSetTest
    {
        public static void Main()
        {
    	HashSet<string> s = HashSetDelegate.Create((string a, string b) => string.Compare(a, b, true) == 0);
        }
    }
