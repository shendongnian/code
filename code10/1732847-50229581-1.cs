    using System;
    
    namespace TestApp
    {
        public enum Foo
        {
            Bar = 123
        }
        
        public class Program
        {
            static void Main()
            {
                // You've parsed these out already
                string name = "Foo";
                string value = "Bar";
                
                // Work out the fully-qualified name and fetch
                // the type. We use the namespace of a type that
                // we know is in the same namespace as the enum we're
                // looking for.
                string ns = typeof(Program).Namespace;
                string fqn = $"{ns}.{name}";
                Type type = Type.GetType(fqn);
                if (type == null)
                {
                    throw new Exception($"Unknown type: {fqn}");
                }
                
                // Parse the value
                object enumValue = Enum.Parse(type, value);
                Console.WriteLine((int) enumValue); // 123
            }
        }
    }
