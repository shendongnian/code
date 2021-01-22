    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            bool same = CreateDelegate(1) == CreateDelegate(1);
        }
        
        private static Action CreateDelegate(int x)
        {
            return new NestedClass(x).ActionMethod;
        }
        
        private class Nested
        {
            private int x;
            
            internal Nested(int x)
            {
                this.x = x;
            }
            
            internal ActionMethod()
            {
                int z = x;
            }
        }
    }
