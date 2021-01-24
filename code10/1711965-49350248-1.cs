        public class Rootobject
        {
            public Firstitem FirstItem { get; set; }
            public Seconditem SecondItem { get; set; }
        }
        public class Firstitem
        {
            public int id { get; set; }
            public string type { get; set; }
            public string[] colours { get; set; }
            public Reviews reviews { get; set; }
        }
        public class Reviews
        {
            public string[] positive { get; set; }
            public string[] negative { get; set; }
            public string[] neutral { get; set; }
        }
        public class Seconditem
        {
            public int id { get; set; }
            public string type { get; set; }
            public string[] colours { get; set; }
            public Reviews1 reviews { get; set; }
        }
        public class Reviews1
        {
            public string[] positive { get; set; }
            public string[] negative { get; set; }
            public string[] neutral { get; set; }
        }
