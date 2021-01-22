        public class Traced 
        {
            public void Method1(String name, Int32 value) {
                using(Tracing tracer = new Tracing()) 
                {
                    [... method body ...]
                }
            }
    
            public void Method2(Object object) { 
                using(Tracing tracer = new Tracing())
                {
                    [... method body ...]
                }
            }
        }
