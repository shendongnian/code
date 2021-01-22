    public class Order : IComparable
    {
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public int CompareTo(object obj)
        {
            Order orderToCompare = obj as Order;
            if (orderToCompare.OrderDate < OrderDate)
            {
                return 1;
            }
            if (orderToCompare.OrderDate > OrderDate)
            {
                return -1;
            }
            if (orderToCompare.OrderId > OrderId)
            {
                return -1;
            }
            if (orderToCompare.OrderId < OrderId)
            {
                return 1;
            }
            return 0;
        }
    }
