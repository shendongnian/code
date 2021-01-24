    public class CustomerMap : BaseCustomerMap
    {
        public CustomerMap(EntityTypeBuilder<Customer> entityBuilder)
            : base(entityBuilder)
        {
            entityBuilder
                .HasAlternateKey(t => t.AdditionalIntField );
        }
    }
