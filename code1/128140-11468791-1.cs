    public class OrderAdapter : IOrderAdapter
    {
        public void Add(IOrder order)
        {
            try
            {
                using (var db = new ATPDataContext())
                {
                    Order newOrder = (Order)order;
                    newOrder.Detach(); // not required for insertion, but to keep references to Product 
                    db.Orders.InsertOnSubmit(newOrder);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {                
            }
        }
     }
