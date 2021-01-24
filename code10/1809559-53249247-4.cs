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
