    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFrom("SomeLibrary.dll");
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine($"Type name: {type}");
                var functions = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (var function in functions)
                {
                    Console.WriteLine($"Function name: {function.Name}");
                    var instance = Activator.CreateInstance(type, null, null);
                    var response = function.Invoke(instance, new[] { "Hello from dynamically loaded assembly" });
                    Console.WriteLine($"Function response: {response}");
                }
            }
            Console.ReadLine();
        }
    }
