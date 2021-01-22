    namespace ConsoleApp
    {
        enum Foo { Bar = 5 }
    
        class Program
        {
            static void Main()
            {
                // Get the assembly containing the enum - Here it's the one executing
                var assembly = Assembly.GetExecutingAssembly();
    
                // Get the enum type
                var enumType = assembly.GetType("ConsoleApp.Foo");
    
                // Get the enum value
                var enumBarValue = enumType.GetField("Bar").GetValue(null);
    
                // Use the enum value
                Console.WriteLine("{0}|{1}", enumBarValue, (int)enumBarValue);
            }
        }
    }
