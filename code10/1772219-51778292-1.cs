    public class StoreEntity
    {
        Person PersonEntity { get; set; }
        Customer CustomerEntity { get; set; }
        List<Sale> SalesList { get; set; }
    
        public StoreEntity(Person p, Customer c,List<Sale> sales)
        {
            this.PersonEntity = p;
            this.CustomerEntity = c;
            this.SalesList = sales;
        }
    
        public int SalesCount
        {
            get
            {
                if (SalesList == null)
                {
                    return 0;
                }
                else
                {
                    return SalesList.Count;
                }
            }
        }
    }
    
    public List<StoreEntity> Entities { get; set; }
    public void MostOrders()
    {
        List<Person> per = Data.GetAllPersons();
        List<Sale> sale = Data.GetAllSales();
        List<Customer> cus = Data.GetAllCustomers();
    
        Entities = new List<StoreEntity>();
        foreach (Person p in per)
        {
            var cust = cus.Where(x => x.PersonID == p.PersonID).Select(x => x).SingleOrDefault();
            if (cust != null)
            {
                var sales = sale.Where(x => x.CustomerId == cust.CustomerID).ToList();
                StoreEntity entity = new StoreEntity(p, cust, sales);
                Entities.Add(entity);
            } 
        }
    
        // now you have list of all entities with their sales
        // it will be musch easy to manipulate with linq
        // you can do this:
        Entities = Entities.OrderBy(x => x.SalesCount).ToList();
        // or this...
        var bestEntity = Entities.Max(x => x.SalesCount);
    }
