    public class Foo
    {
        private bool _field;
    
        public static class Extensions
        {
            public static bool GetVariable(this Foo foo)
            {
                return foo._field;
            }
        }
    }
