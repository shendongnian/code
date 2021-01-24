    public class PropertyInitializer
    {
        public void Initialize<T>(object obj, T value)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(T))
                {
                    property.SetValue(obj, value);
                }
            }
        }
    }
    public class InitializedBase
    {
        protected InitializedBase()
        {
            var initializer = new PropertyInitializer();
            //Initialize all strings 
            initializer.Initialize<string>(this, "Juan");
            //Initialize all integers
            initializer.Initialize<int>(this, 31);
        }
    }
    //Sample class to illustrate
    public class AutoInitializedClass : InitializedBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return string.Format("My name is {0} and I am {1} years old", Name, Age);
        }
    }
