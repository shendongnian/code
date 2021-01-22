        public interface ProvidesItem1
        {
            int item1 { get; set; }
        }
        public interface ProvidesItem2
        {
            int item2 { get; set; }
        }
        class a : ProvidesItem1, ProvidesItem2
        {
            public int item1 { get; set; }
            public int item2 { get; set; }
        }
        class b : ProvidesItem1
        {
            public int item1 { get; set; }
        }
