    class Program
    {
        static void Main(string[] args)
        {
            var JSONStr = "{\"user\":{\"L9k0\":{\"ID\":\"001\", \"name\":\"somename\"},\"L9k1\":{\"ID\":\"002\", \"name\":\"someothername\"}}}";
            var res = JsonConvert.DeserializeObject<JsonResult>(JSONStr);
            Console.ReadLine();
        }
    }
    class JsonResult {
        public Dictionary<string, ToDoItem> user { get; set; }
    }
    class ToDoItem {
        public string ID { get; set; }
        public string name { get; set; }
    }
