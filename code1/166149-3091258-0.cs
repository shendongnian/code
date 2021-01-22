    using System.Runtime.CompilerServices;
     
    public class Singleton
    {
        private static Singleton Instance = null;
        static readonly object padlock = new object();
     
     
        // The private constructor doesnt allos a default public constructor
        private Singleton() {}
     
        // Synchronized "constructor" to make it thread-safe
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            lock(padlock)
            {
                 if (Instance == null)
                 { 
                      Instance = new Singleton();
                 }
            }
        }
     
        public static Singleton GetInstance()
        {
            if (Instance == null) CreateInstance();
            return Instance;
        }
    }
     
    // Test class
    public class Prueba
    {
       private static void Main(string[] args)
       {
         //Singleton s0 = new Singleton();  //Error
         Singleton s1 = Singleton.GetInstance();
         Singleton s2 = Singleton.GetInstance();
         if(s1==s2)
         {
           // Misma instancia
         }
       }
    }
