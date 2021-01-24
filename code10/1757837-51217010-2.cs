    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = File.ReadAllText("D://readjson.txt");
                var datavales = JsonConvert.DeserializeObject<RootObject>(data);
    
                foreach(var vales in datavales.myObj2)
                {
                    //access values from here
                    Console.WriteLine(vales.name);
                }
            }
        }
        public class Parameter
        {
            public string paramName { get; set; }
            public string type { get; set; }
            public string value { get; set; }
        }
    
        public class MyObj2
        {
            public string name { get; set; }
            public List<Parameter> parameters { get; set; }
        }
    
        public class RootObject
        {
            public List<MyObj2> myObj2 { get; set; }
        }
    }
