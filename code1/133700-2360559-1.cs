    public class C
    {
        private static C instance;
        private C()
        {
            // do some stuff
        }
        public static C GetInstance()
        {
            if(instance==null)
               instance = new C();
            return instance;
        }
    }
