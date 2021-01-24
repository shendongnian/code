    class Item1
    {
        public string id;
        public string id_alt;
        public string item1_code;
        public Item1()
        {
            id = "";
            item1_code = "";
        }
    }
    class Item2
    {
        public string id;
        public string id_alt;
        public Item2()
        {
            id = "";
        }
        public void AccessItem1Prop(Parent parent) {
            string item1ID = parent.items1[0].id;
        }
    }
