    public class OrderComparer : IEqualityComparer<Order>
    {
        public bool Equals(Order o1, Order o2)
        {
            return o1.OrderID == o2.OrderID;
        }
        public int GetHashCode(Order obj)
        {
            return obj.OrderID.GetHashCode();
        }
    }
 
