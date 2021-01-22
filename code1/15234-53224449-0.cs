    public class Singleton
    {
       private static Singleton _instance;
       public static Singleton Instance => _instance ?? (_instance = new Singleton());
    }
