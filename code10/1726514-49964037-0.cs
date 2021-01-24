    using Newtonsoft.Json;
    using System;
    
    namespace JsonTest
    {
        public class Base
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = 1, PropertyName = "A")]
            public string A { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = 2, PropertyName = "X")]
            public string X { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = 3, PropertyName = "B")]
            public string B { get; set; }
        }
        public class Derived : Base
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = 4, PropertyName = "C")]
            public string C { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = 5, PropertyName = "X")]
            public new string X
            {
                get => base.X;
                set => base.X = value;
            }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, Order = 6, PropertyName = "D")]
            public string D { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Base b = new Base() { A = "a", B = "b", X = "x" };
                string serB = JsonConvert.SerializeObject(b);
                Console.WriteLine($"Serialized base class:\r\n {serB}");
    
                Derived d = new Derived() { A = "a", B = "b", C = "c", D = "d", X = "x" };
                string serD = JsonConvert.SerializeObject(d);
                Console.WriteLine($"Serialized derived class:\r\n {serD}");
            }
        }
    }
