    public class BaseCustomerMap<TEntity>
        where TEntity : BaseCustomer
    {
        public BaseCustomerMap(EntityTypeBuilder<TEntity> entityBuilder)
        {
            entityBuilder
                .HasKey(t => t.Id );
            entityBuilder.Property(t => t.Id)
                .ValueGeneratedOnAdd();
        }
    }
