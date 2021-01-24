        public class Customer
        {
            public int Id;
            public CustomerAddress StatementAddress;
            [Column("StatementAddress_ForStatement")]
            public bool AlwaysTrue => true;
            [Column("StatementAddress_CustomerCode")]
            public string Code;
        }
