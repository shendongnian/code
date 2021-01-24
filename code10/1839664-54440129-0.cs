    class Program
    {
        static void Main()
        {
            TellMeAboutType(typeof(string));
        }
        static void TellMeAboutType(Type type)
        {
            Console.WriteLine("Name: " + type.Name);
            Console.WriteLine("Namespace: " + type.Namespace);
            Console.WriteLine("Assembly: " + type.Assembly.FullName);
            Console.WriteLine("AQN: " + type.AssemblyQualifiedName);
            Console.WriteLine("Abstract: " + type.IsAbstract);
            Console.WriteLine("Generic: " + type.IsGenericType);
            Console.WriteLine("Sealed: " + type.IsSealed);
            Console.WriteLine("Base Type: " + type.BaseType.FullName);
            foreach(var iType in type.GetInterfaces())
            {
                Console.WriteLine("Implements: " + iType.FullName);
            }
        }
    }
