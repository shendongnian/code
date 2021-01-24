     public class Foo
        {
            [JsonProperty]
            String A;
            [JsonProperty]
            String B;
            [JsonProperty]
            Int32 C;
            [JsonProperty]
            DateTime D;
        }
    
        public class Bar
        {
            public Bar()
            {
                H = new Foo();
            }
            [JsonProperty]
            String G;
            [JsonProperty]
            Foo H;
            public String E { get; set; }
            public String F { get; set; }
        }
