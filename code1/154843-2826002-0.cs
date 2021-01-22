    int orderId = 4;
    TextWriter textWriter = new StringWriter();
    using (var dc = new DataClasses1DataContext())
    {
        dc.Log = textWriter;
        Order o1 = dc.Orders.FirstOrDefault(x => x.OrderId == orderId);
        Order o2 = dc.Orders.FirstOrDefault(x => x.OrderId.Equals(orderId));
    }
    string log = textWriter.ToString();
