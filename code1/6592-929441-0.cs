/// &lt;summary&gt;Abstract base class for thread-safe singleton objects&lt;/summary&gt;
/// &lt;typeparam name="T"&gt;Instance type&lt;/typeparam&gt;
public abstract class SingletonOnDemand&lt;T&gt; {
  private static object __SYNC = new object();
  private static volatile bool _IsInstanceCreated = false;
  private static T _Instance = default(T);
  /// &lt;summary&gt;Instance data&lt;/summary&gt;
  public static T Instance {
    get {
      if (!_IsInstanceCreated)
        lock (__SYNC)
          if (!_IsInstanceCreated) {
            _Instance = Activator.CreateInstance&lt;T&gt;();
            _IsInstanceCreated = true;
          }
          return _Instance;
    }
  }
}
