    orderList.Sort(
        delegate(Order p1, Order p2)
        {
            int compareDate = p1.Date.CompareTo(p2.Date);
            if (compareDate == 0)
            {
                return p2.OrderID.CompareTo(p1.OrderID);
            }
            return compareDate;
        }
    );
