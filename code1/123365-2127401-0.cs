    public partial class Customer
    {
        public static Customer GetCustomer(Int64 custID)
        {
            using (var db = new MyDataContext(Settings.MyConnectionString))
            {
                return db.Customers.SingleOrDefault(c => c.ID == custID);
            }
        }
        ...
    }
