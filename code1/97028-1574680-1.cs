        public IEnumerable<Order> GetOrdersWithProduct(int productId)
        {
            List<Order> orders = OrderService.GetTestData();
            var result = orders.Where(o => o.Items.Any(i => i.ProductId == productId));
            return result.ToList();
        }
        public IEnumerable<Order> GetOrdersWithProduct(IEnumerable<int> productIds)
        {
            List<Order> orders = OrderService.GetTestData();
            var result = orders.Where(o => productIds.All(id => o.Items.Any(i => i.ProductId == id)));
            return result.ToList();
        }
