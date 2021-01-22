    public static class Singleton<T> where T : new()
    {
    	public static T Instance { get; private set; }
    
    	static Singleton() { Instance = new T(); }
    }
