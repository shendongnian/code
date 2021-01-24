        public class Customer
        {
            public int Id;
            public CustomerAddress StatementAddress;
            [ForeignKey("StatementAddress"), Column(Order = 1)]
            public bool AlwaysTrue => true;
            [ForeignKey("StatementAddress"), Column(Order = 0)]
            public string Code;
        }
