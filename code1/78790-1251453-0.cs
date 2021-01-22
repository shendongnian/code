    public class Foobar
    {
        private static int numInstances = 0;
        public static Foobar CreateFoobar()
        {
            if (numInstances++ < 10)
            {
                return new Foobar();
            }
            return null;
        }
        protected Foobar()
        {
            ...
        }
    }
