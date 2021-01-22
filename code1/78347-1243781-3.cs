        public class Person
        {
            public string FirstName { get; set; }
            public string MI { get; set; }
            public string LastName { get; set; }
            public override string ToString()
            {
                return "FirstName=\"" + FirstName + "\" p.MI=\"" + MI + "\" p.LastName=\"" + LastName + "\"";
            }
        }
