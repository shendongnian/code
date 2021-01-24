      static void Main(string[] args)
        {
            var objectToSerialize = new List<IFoo>() {
                new TestClass()
                {
                    Test = "A",
                    Test2 = "B"
                },
                  new TestClass2()
                {
                    Test = "C",
                    Test3 = "D"
                },
            };
            // TODO: Add objects to list
            var jsonString = JsonConvert.SerializeObject(objectToSerialize, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            var deserializedObject = JsonConvert.DeserializeObject<List<IFoo>>(jsonString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            var result = deserializedObject;
        }
    }
    internal interface IFoo
    {
         string Test { get; set; }
    }
    public class TestClass : IFoo
    {
        public string Test { get; set; }
        public string Test2 { get; set; }
    }
    public class TestClass2 : IFoo
    {
        public string Test { get; set; }
        public string Test3 { get; set; }
    }
