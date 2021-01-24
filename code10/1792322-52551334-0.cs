    public class Type1
    {
        public void M()
        {
        }
    }
    public class Type2
    {
        public void M()
        {
        }
    }
    public static class Extension
    {
        public static void A<T>(T obj) where T : Type1 or Type2
        {
            obj.M();
        }
    }
