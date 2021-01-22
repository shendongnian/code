    public class Order : IOrderDetails
        {
            public int OrderID { get; set; }
            public string CustID { get; set; }
            public string Details { get; set; }
        }
        public interface IOrderDetails
        {
            public int OrderID { get; set; }
            public string Details { get; set; }
        }
        public List<IOrderDetails> Get(string id)
        {
            List<Order> orders = new List<Order>(); // pass this in as a param or globally refer to it
            
            var query = from o in orders
                        where o.CustID == id
                        select o as IOrderDetails;
            return query.ToList();
        }
