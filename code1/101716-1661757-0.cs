    public class CustomerProvider
    {
        PositionProvider<CustomerEntity> _provider;
        PositionProvider<CustomerEntity> Instance // we don't need it public really.
        {
            get
            {
                if ((int)PositionProvider<CustomerEntity>.Instance.PositionType == 0)
                {
                    _provider = new PositionProvider<CustomerEntity>(); // PositionType is set in .ctor
                    // we can also use a factory to abstract away DB differences
                }
                return _provider;
            }
        }
        // one way of implementing custom query
        public List<CustomerEntity> GetCustomersByUserPermission(Guid userId){
            return _provider.GetListWithCriteria(Criteria.Argument("UserId", userId));
        }
    }
