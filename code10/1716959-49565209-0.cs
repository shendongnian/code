        public class Weee
        {
            public string name { get; set; }
            public int order { get; set; }
            public string whatever { get; set; }
            public Weee()
            {
                PropertyInfo[] properties = typeof(Weee).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(this, "wut");
                    }
                }
            }
        }
