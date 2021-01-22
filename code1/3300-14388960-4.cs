    public abstract class DefaultValueInitializer
    {
        protected DefaultValueInitializer()
        {
            InitializeDefaultValues(this);
        }
        public static void InitializeDefaultValues(object obj)
        {
            var props = from prop in obj.GetType().GetProperties()
                        let attrs = prop.GetCustomAttributes(typeof(InstanceAttribute), false)
                        where attrs.Any()
                        select new { Property = prop, Attr = ((InstanceAttribute)attrs.First()) };
            foreach (var pair in props)
            {
                object value = !pair.Attr.IsConstructorCall && pair.Attr.Values.Length > 0
                                ? pair.Attr.Values[0]
                                : Activator.CreateInstance(pair.Property.PropertyType, pair.Attr.Values);
                pair.Property.SetValue(obj, value, null);
            }
        }
    }
