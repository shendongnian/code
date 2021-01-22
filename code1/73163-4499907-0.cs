        public class CustomersService : RestServiceBase<Customers>
        {
                public IDbConnectionFactory DbFactory { get; set; }
                public override object OnGet(Customers request)
                {
                  return new CustomersResponse { Customers = DbFactory.Exec(dbCmd =>
                        dbCmd.Select<Customer>()) 
                };
        }
