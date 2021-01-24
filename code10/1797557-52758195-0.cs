        public CustomerDto GetCustomer(int id)
        {
            CustomerDto customer = Mapper.Map<CustomerExtendedDto, CustomerDto>(GetCustomerExtended(id));
            return customer;
        }
