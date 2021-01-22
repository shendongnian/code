    public abstract class CustomerProvider : PositionProvider<CustomerEntity>
    {
    
            public CustomerProvider() { }
    
            public new static CustomerProvider Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        DalHelper.CreateInstance<CustomerProvider>(out _instance);
                    }
                    return _instance;
                }
            }
            private static CustomerProvider _instance;
    
            public override List<CustomerEntity> GetList()
            {
                return PositionProvider<CustomerEntity>.Instance.GetList();
            }
    
            public abstract List<CustomerEntity> GetCustomersByUserPermission(Guid userId);
    
    }
