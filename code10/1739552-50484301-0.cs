    public class MyClass
    {
        public IMyInterface<Foo> Foos { get; set; }
        public IMyInterface<Bar> Bars { get; set; }
    
        public IMyInterface<T> Interfaces<T>()
        {
            var property = GetType().GetProperties()
                .Where(x => x.PropertyType.Name.StartsWith("IMyInterface")
                            &&
                            x.PropertyType.GenericTypeArguments.Contains(typeof(T)))
                .FirstOrDefault();
    
            if (property != null)
                return (IMyInterface<T>)property.GetValue(this);
            return null;
        }
    }
