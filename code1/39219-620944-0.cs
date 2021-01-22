    public class CustomerMapper : ClassMap<Customer>
    {
        private const string schema = "Sales";
        public CustomerMapper()
        {
            SchemaIs(schema);
            Id(x => x.CustomerID);
            Map(x => x.CustomerType).WithLengthOf(1).Not.Nullable();
            Map(x => x.AccountNumber).ReadOnly()
               .Generated(Generated.Insert);
            References(x => x.Territory).LazyLoad();
        }
    }
