    public interface IMapper<TSource, TDest>
    {
        TDest Map(TSource source);
    }
    public CustomerToTestCustomerFormMapper: IMapper<Customer, TestCustomerForm>
    {
        static CustomerToTestCustomerFormMapper()
        {
            // TODO: Configure the mapping rules here
        }
        public TestCustomerForm Map(Customer source)
        {
            return Mapper.Map<Customer, TestCustomerForm>(source);
        }
    }
