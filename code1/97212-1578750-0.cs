    public class CustomerOrdersMap : IAutoMappingOverride<CustomerOrders>
        {
            public void Override(AutoMapping<CustomerOrders> mapping)
            {
                mapping.Table("CUSTOMER_ORDERS");
    
                
            }
        }
