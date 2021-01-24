        private const string methodName = "Execute";
        public static void Main()
        {
            ExampleClass1 e1 = new ExampleClass1();
            ExampleClass2 e2 = new ExampleClass2();
            ExampleClass3 e3 = new ExampleClass3();
            /* Code below Simulates:  "e3.GetString = e2.Execute;" */
            var method = e2.GetType().GetMethod(methodName);            
            Type methodType = method.ReturnType;
            
            // Create a Func<T> that will invoke the target method            
            var funcType = typeof(Func<>).MakeGenericType(methodType);
            var del = Delegate.CreateDelegate(funcType, e2, method);
            var properties = e3.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {              
                // Check that its the same return type as delegate
                if (!properties[i].PropertyType.IsAssignableFrom(funcType))
                    continue;
              
                properties[i].SetValue(e3, del );
            }
            /* Code above Simulates:  "e3.GetString = e2.Execute;" */
            e2.GetNumber = e1.Execute;
            e3.Execute();
            // Read the key
            Console.ReadKey();
        }
        public class ExampleClass3
        {         
            public Func<String> GetString { get; set; }
            public Func<int> GetInt { get; set; }
            public ExampleClass3()
            { }
            public object Execute()
            {
                Console.WriteLine(GetString());
                return null;
            }
        }
        public class ExampleClass2
        {
            public Func<int> GetNumber { get; set; }
            public string Execute() => $"Your Number Is {GetNumber()}";
        }
        public class ExampleClass1
        {
            public int number = 5;
            public int Execute() => number;
        }
