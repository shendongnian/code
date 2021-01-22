    public class MyOrderingClass : IComparer<Order>
    {
        public int Compare(Order x, Order y)
        {
            int compareDate = x.Date.CompareTo(y.Date);
            if (compareDate == 0)
            {
                return x.OrderID.CompareTo(y.OrderID);
            }
            return compareDate;
        }
    }
