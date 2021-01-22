    Orders orders = new Orders();
    Order work = new Order() { ItemNumber = "0123993587", OrderNumber = "12345", QTY = 10, WareHouse = "PA019" };
    orders.OrderList.Add(work);
    work = new Order() { ItemNumber = "0123993587", OrderNumber = "12346", QTY = 9, WareHouse = "PA019" };
    orders.OrderList.Add(work);
    work = new Order() { ItemNumber = "0123993587", OrderNumber = "12347", QTY = 8, WareHouse = "PA019" };
    orders.OrderList.Add(work);
    XmlSerializer ser = new XmlSerializer(typeof(Orders));
    using(StreamWriter wr = new StreamWriter(@"D:\testoutput.xml", false, Encoding.UTF8))
    {
        ser.Serialize(wr, orders);
    }
