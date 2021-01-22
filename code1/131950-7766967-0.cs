        public static IList GetHistory(DateTime time, string contact = "")
        {
            using (Entities entities = new Entities())
            {
                //....your code
                return convs.ToList();
            }
        }
