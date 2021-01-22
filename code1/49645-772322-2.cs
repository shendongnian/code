    using System;
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
            ISetter setter = Setter.Create(typeof(Foo), "Bar");
            Foo foo = new Foo();
            setter.SetValue(foo, "abc");
            string s = foo.ToString(); // prove working
        }
    }
    public interface ISetter {
        void SetValue(object target, object value);
    }
    public static class Setter
    {
        public static ISetter Create(Type type, string propertyName)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (propertyName == null) throw new ArgumentNullException("propertyName");
            return Create(type.GetProperty(propertyName));
        }
        public static ISetter Create(PropertyInfo property)
        {
            if(property == null) throw new ArgumentNullException("property");
            if (!property.CanWrite) throw new InvalidOperationException("Property cannot be written");
            Type type = typeof(TypedSetter<,>).MakeGenericType(
                    property.ReflectedType, property.PropertyType);
            return (ISetter) Activator.CreateInstance(
                type, property.GetSetMethod());
        }
    }
    
    public class TypedSetter<TTarget, TValue> : ISetter {
        private readonly Action<TTarget, TValue> setter;
        public TypedSetter(MethodInfo method) {
            setter = (Action<TTarget, TValue>)Delegate.CreateDelegate(
                typeof(Action<TTarget, TValue>), method);
        }
        void ISetter.SetValue(object target, object value) {
            setter((TTarget)target, (TValue)value);
        }
        public void SetValue(TTarget target, TValue value) {
            setter(target, value);
        }
    }
