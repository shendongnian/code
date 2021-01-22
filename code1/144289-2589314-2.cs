    public sealed class SingletonAPI
    {
         public static SingletonAPI Instance { get; private set; }
    
         private SingletonAPI() {}
    
         static SingletonAPI() { Instance = new SingletonAPI(); }     
    
         // API method:
         public void DoSomething() { Console.WriteLine("hi"); }
    }
