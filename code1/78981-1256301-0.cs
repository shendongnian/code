    using System;
    namespace GenericCastRuntime
    {
        class Program
        {
            static void Main(string[] args)
            {
                string type = "GenericCastRuntime.Program+Provider`1";
                Type t = Type.GetType(type);
    
                string genericType = "System.String";
                Type gt = Type.GetType(genericType);
    
                var objType = t.MakeGenericType(gt);
                var ci = objType.GetConstructor(Type.EmptyTypes);
                var obj = ci.Invoke(null);
                IProvider provider = obj as IProvider;
            }
    
            public class Provider<T> : IProvider<T>
            {
                public T Value { get; set; }
    
                object IProvider.Value
                {
                    get { return this.Value; }
                    set
                    {
                        if (!(value is T)) throw new InvalidCastException();
                        this.Value = (T)value;
                    }
                }
    
            }
    
            public interface IProvider { object Value { get; set; } }
            public interface IProvider<T> : IProvider { T Value { get; set; } }
        }
    }
