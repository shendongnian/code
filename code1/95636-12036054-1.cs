    public class Foo
    {
        private bool _variable;
    
        public static class Extensions
        {
            public static bool GetVariable(this Foo foo)
            {
                return foo._variable;
            }
        }
    }
