	public sealed class Singleton   
	{   
	// private static Singleton instance; (instead of this, it should be like this, see below)
	private static readonly Singleton instance = new Singleton();     
	static Singleton(){}
	private Singleton() {}    public static Singleton Instance{   get   { if (instance == null)            instance = new Singleton();   return instance;}}}
