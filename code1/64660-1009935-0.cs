    public class Class1
    {
        private static Class1 oInstance = null;
        private Class1() { }
        public static Class1 GetInstance()
        {
            if (oInstance == null)
            {
                lock(typeof(Class1))
                {
                    if (oInstance == null)
                    {
                        oInstance = new Class1();
                    }
                }
            }
            return oInstance ;
        }
    }
