    class OrderService
    {
        public void AddProduct(int orderId, int productId)
        {
            Order order = this.orderRepository.FirstOrDefault(orderId);
            Product product = this.productRepository.FirstOrDefault(productId);
            
            if(!order.Products.Contains(product)
            {
                order.Products.Add(product);
            }
            this.orderRepository.Save(order);
        }
    }
