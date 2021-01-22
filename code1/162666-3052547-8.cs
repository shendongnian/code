    public Order[] GetAllOrders()
    {
        IQueryable orders = GetAllOrdersInternal();
        orders = BusinessSecurity.ApplySecurityOnOrders(orders);
        return orders.ToArray();
    }
    static class BusinessSecurity
    {
        public static IQueryable<Order> ApplySecurityOnOrders(
           IQueryable<Order> orders)
        {
            var user = Membership.GetCurrentUser();
            if (user.IsInRole("Administrator"))
            {
                return orders;
            }
            return 
                from order in orders
                where order.Customer.User.Name == user.Name
                select order; 
        }
    }
