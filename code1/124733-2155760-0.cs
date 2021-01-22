public class Singleton
{
  private Singleton()
  {
    // Prevent outside instantiation
  }
  private static Singleton _singleton;
  
  public static Singleton GetSingleton()
  {
    if ( _singleton == null )
    {
      _singleton = new Singleton();
    }
    return _singleton;
  }
}
