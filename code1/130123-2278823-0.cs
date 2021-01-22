    static class Customers
    {
       public static Customer AsCustomer(this Person person)
       {
           return (Customer)person;
       }
    }
    customer.WIthLastName("Bob").AsCustomer().WithId(10);
