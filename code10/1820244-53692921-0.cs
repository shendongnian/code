    public class TypeMapping : EntityTypeConfiguration<Type>
        {
            public TypeMapping()
            {
                // Keys
                HasKey(t => t.ID);
    
                //Property
                Property(t => t.SignUpFee);
                Property(t => t.Discount);            
    
                //Table
                ToTable("Type");
            }
        }
    public class CustomerMapping : EntityTypeConfiguration<Customer>
            {
                public CustomerMapping()
                {
                    // Keys
                    HasKey(t => t.ID);
        
                    //Property
                    Property(t => t.Name);
        
                    //Table
                    ToTable("Customer");
                }
            }
