    class Lst1
    {
        public string filed1 { get; set; }
        public string filed2 { get; set; }
        public string filed3 { get; set; }
        public string filed4 { get; set; }
        public string filed5 { get; set; }
    }
    class Lst2
    {
        public string filed1 { get; set; }
        public string filed2 { get; set; }
        public string filed3 { get; set; }
        public string filed4 { get; set; }
        public string filed5 { get; set; }
        public string filed6 { get; set; }
    }
    void CopyData()
    {
            // test data
            List<Lst1> Lst1_ = new List<Lst1>()
            {
                new Lst1()
                {
                    filed1 = "1",
                    filed2 = "2",
                    filed3 = "3",
                    filed4 = "4",
                    filed5 = "5",
                },
                new Lst1()
                {
                    filed1 = "6",
                    filed2 = "7",
                    filed3 = "8",
                    filed4 = "9",
                    filed5 = "10",
                },
            };
            List<Lst2> Lst2_ = new List<Lst2>();
            foreach (var item in Lst1_)
            {
                Type type1 = item.GetType();
                PropertyInfo[] properties1 = type1.GetProperties();
                var current = new Lst2();
                Type type2 = current.GetType();
                PropertyInfo[] properties2 = type2.GetProperties();
                int k = 0;
                foreach (PropertyInfo property in properties1)
                {
                    var value = property.GetValue(item, null);
                    properties2[k].SetValue(current, value);
                    k++;
                }
                Lst2_.Add(current);
            }
    }
