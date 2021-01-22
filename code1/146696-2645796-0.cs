    class Program
        {
            static void Main(string[] args)
            {
                var property = typeof(Test).GetProperty("Accessor");
    
                var methods = property.GetAccessors();
            }
        }
    
    
    
        public class Test
        {
            public string Accessor
            {
    
                get;
                private set;
            }    
    
        }
