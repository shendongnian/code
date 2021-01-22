        public partial class MyContext : DbContext
        {
            public MyContext() : base("name=MyContext")
            {
            }
            // --- Here is the new thing:
            public MyContext(string entityConnectionString) : base(entityConnectionString)
            {
            }
            // --- New thing ends here
            // .... the rest of the dbcontext implementation follows below 
        } 
