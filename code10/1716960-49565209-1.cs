        public class Weee
        {
            public string name { get; set; }
            public int order { get; set; }
            public string whatever { get; set; }
            public Weee()
            {
                foreach(var p in typeof(Weee).GetProperties().Where(a => a.PropertyType == typeof(string)))
                {
                    p.SetValue(this, "wut");
                }
            }
        }
