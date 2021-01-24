    using System;
    using Newtonsoft.Json;
    
    interface IFoo
    {
        void Method();
    }
    
    class Foo1 : IFoo
    {
        public string Name { get; set; }
        public void Method() => Console.WriteLine("Method in Foo1");
    }
    
    class Foo2 : IFoo
    {
        public int Value { get; set; }
        public void Method() => Console.WriteLine("Method in Foo2");
    }
    
    class Root
    {
        public IFoo First { get; set; }
        public IFoo Second { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            Root root = new Root
            { 
                First = new Foo1 { Name = "Fred" },
                Second = new Foo2 { Value = 10 }
            };
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string json = JsonConvert.SerializeObject(root, settings);
            
            Console.WriteLine(json);
            
            Root root2 = JsonConvert.DeserializeObject<Root>(json, settings);
            root2.First.Method();
            root2.Second.Method();
        }
    }
