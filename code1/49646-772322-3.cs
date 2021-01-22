    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    class Foo
    {
        public string Bar { private get; set; }
        public override string ToString()
        {
            return Bar; // to prove working
        }
    }
    static class Program
    {
        static void Main()
        {
            Action<object,object> setter = Setter.Create(typeof(Foo), "Bar");
            Foo foo = new Foo();
            setter(foo, "abc");
            string s = foo.ToString();
        }
    }
    
    public static class Setter
    {
        public static Action<object,object> Create(Type type, string propertyName)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (propertyName == null) throw new ArgumentNullException("propertyName");
            return Create(type.GetProperty(propertyName));
        }
        public static Action<object,object> Create(PropertyInfo property)
        {
            if(property == null) throw new ArgumentNullException("property");
            if (!property.CanWrite) throw new InvalidOperationException("Property cannot be written");
    
            var objParam = Expression.Parameter(typeof(object), "obj");
            var valueParam = Expression.Parameter(typeof(object), "value");
            var body = Expression.Call(
                Expression.Convert(objParam, property.ReflectedType),
                property.GetSetMethod(),
                Expression.Convert(valueParam, property.PropertyType));
            return Expression.Lambda<Action<object, object>>(
                body, objParam, valueParam).Compile();
        }
    }
