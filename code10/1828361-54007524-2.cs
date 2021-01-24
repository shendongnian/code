    public class MySingleton : Singleton<MySingleton>
    {
         // Don't use the Awake method, Singleton uses it to initialize
    
         void Start() {
             Debug.Log("I'm a Singleton, access me through MySingleton.Instance");
         }
    }
