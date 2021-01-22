    public static string GetFormattedOrderId(object dataItem)
    {
        Order order = (Order) dataItem;
        return String.Format("WW{0:N7}", order.OrderId);      \
        // or return order.OrderId.ToString().PadLeft... if you prefer
    }
