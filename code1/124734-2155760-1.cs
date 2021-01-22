public class Singleton
{
    private Singleton()
    {
        // Prevent outside instantiation
    }
    private static readonly Singleton _singleton = new Singleton();
    public static Singleton GetSingleton()
    {
        return _singleton;
    }
}
