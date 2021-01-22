    public class Adapter
    {
        public static Adapter Instance => Singleton<Adapter>.Instance; 
        // private Adapter(){ } // doesn't compile.
    }
