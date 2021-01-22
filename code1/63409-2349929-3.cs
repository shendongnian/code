    public class UniqueEmailAttribute : IocValidationAttribute
    {
        public override bool IsValid(object value)
        {
            ICustomerRepository customerRepository = Resolve<ICustomerRepository>();
    
            return customerRepository.FindByEmail(value.ToString()) == null;
        }
    }
