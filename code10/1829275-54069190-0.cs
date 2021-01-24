    namespace ServiceInterface.Models
    {
    public static  class ExtensionClass
    {
        public static List<Customer> ConvertCustomer(this List<Customer> customers)
        {
            return customers.Select(
                c =>
                new Customer
                {
                    FirstName = c.FirstName + " " + c.LastName,
                    LastName = "",
                    Gender = c.Gender
                }).ToList();
        }
    }
    }
