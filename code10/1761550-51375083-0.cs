    LoginResult loginResult = JsonConvert.DeserializeObject<RootObject>(result.ToString());
        public class Tm
        {
            public string name { get; set; }
            public string url { get; set; }
        }
        
        public class RootObject
        {
            public string sctoken { get; set; }
            public List<Tm> tms { get; set; }
            public string user_descr { get; set; }
        }
