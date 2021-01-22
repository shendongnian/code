        class B
        {
            public int MyProperty { get; set; }
        }
        class C : B
        {
            public string MyProperty2 { get; set; }
        }
        static void Main(string[] args)
        {
            PropertyInfo[] info = new C().GetType().GetProperties();
            foreach (var pi in info)
            {
                Console.WriteLine(pi.Name);
            }
        }
