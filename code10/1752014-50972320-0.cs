    namespace x {
        public class Something
        {
            public string abc { get; set; }
        }
        static void Main(string[] args)
        {
            Something newtonsoft = JsonConvert.DeserializeObject<Something>("");
         }
    }
