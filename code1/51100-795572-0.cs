    public class InitOnLoad : Attribute 
    { 
        public static void Initialise()
        {
            // get a list of types which are marked with the InitOnLoad attribute
            var types = 
                from t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                where t.GetCustomAttributes(typeof(InitOnLoad), false).Count() > 0
                select t;
    
            // process each type to force initialise it
            foreach (var type in types)
            {
                // try to find a static field which is of the same type as the declaring class
                var field = type.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic).Where(f => f.FieldType == type).FirstOrDefault();
                // evaluate the static field if found
                if (field != null) field.GetValue(null);
            }
        }
    }
    
    [InitOnLoad]
    public class Foo
    {
        public static Foo x = new Foo();
    
        private Foo()
        {
            Console.WriteLine("Foo is automatically initialised");
        }
    }
    
    public class Bar
    {
        public static Bar x = new Bar();
    
        private Bar()
        {
            Console.WriteLine("Bar is only initialised as required");
        }
    }
