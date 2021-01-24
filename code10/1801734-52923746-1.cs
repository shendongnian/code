    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"C:\Users\xxx\source\repos\ConsoleApp4\ConsoleApp4\Files\json6.json");
            JObject data = JObject.Parse(json);
            //Getting all those children that have value are empty from outer json
            var result1 = data.Children<JProperty>()
                 .Where(x => (x.Value.Type == JTokenType.Object) && !x.Value.HasValues)
                .ToList();
            //Getting all those children that have value are empty from "question" object
            var result2 = data["question"].Children<JProperty>()
                .Where(x => (x.Value.Type == JTokenType.Object && !x.Value.HasValues) || (x.Value.Type == JTokenType.Array && !x.Value.HasValues))
                .ToList();
            //Remove all above empty object or arrays
            result1.ForEach(x => x.Remove());
            result2.ForEach(x => x.Remove());
            var obj = data.ToObject<JObject>();
            Console.WriteLine(obj);
            Console.ReadLine();
        }
    }    
