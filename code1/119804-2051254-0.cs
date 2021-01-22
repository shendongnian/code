    public class OrderService 
    { 
        public Order GetOrder(orderId)
        {
            return Dao.GetOrderById(orderId);
        }
 
 
        public void AddProduct(Order order, Product product) 
        {
            // The way this method works seems like it should be in a ProductService
            // rather than in the OrderService.
            product.OrderId = _order.Id;
            ProductDao.Add(product); 
        } 
 
    }
