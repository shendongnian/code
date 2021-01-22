        class DataConcierge
        {
            public static T Create<T>(int id)
            {
                // ...
            }
            public static void Save<T>(params T[] items)
            {
                // ...
            }
        }
        static void Main(string[] args)
        {
            var customer = DataConcierge.Create<Customer>(123);
            // ...
            DataConcierge.Save(customer); // this works!
            //----------------------------------------------------
            // or
            //----------------------------------------------------
            
            var customers = new Customer[]
            {
                DataConcierge.Create<Customer>(123),
                DataConcierge.Create<Customer>(234),
                DataConcierge.Create<Customer>(345),
            };
            // ...
            DataConcierge.Save(customers); // this works too!
        }
