     internal class ExpandObject
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public string coolProp { get; set; }
            public string otherProp { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                String text = "{\"data\":[{\"Id\":1,\"Text\":\"Test1\",\"coolProp\":213},{\"Id\":2,\"Text\":\"Test2\"},{\"Id\":3,\"Text\":\"Test3\",\"otherProp\":\"cool\"}]}";
                var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExpandObject>>(Convert.ToString(JObject.Parse(text)["data"]));
                Console.ReadLine();
            }
        }
