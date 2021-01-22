    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.CustomerId);
            Join("CustomerName", m =>
            {
                m.Map(x => x.FirstName);
                m.Map(x => x.LastName);
            });
            // ... other properties ...
        }
    }
