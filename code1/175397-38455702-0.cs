    public class Order
    {
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    
        public Order(string orderId, DateTime orderDate, int quantity, int total)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            Quantity = quantity;
            Total = total;
        }
    }
    
    public void SampleDataAndTest()
    {
        List<Order> objListOrder = new List<Order>();
    
        objListOrder.Add(new Order("tu me paulo ", Convert.ToDateTime("01/06/2016"), 1, 44));
        objListOrder.Add(new Order("ante laudabas", Convert.ToDateTime("02/05/2016"), 2, 55));
        objListOrder.Add(new Order("ad ordinem ", Convert.ToDateTime("03/04/2016"), 5, 66));
        objListOrder.Add(new Order("collocationem ", Convert.ToDateTime("04/03/2016"), 9, 77));
        objListOrder.Add(new Order("que rerum ac ", Convert.ToDateTime("05/02/2016"), 10, 65));
        objListOrder.Add(new Order("locorum ; cuius", Convert.ToDateTime("06/01/2016"), 1, 343));
    
    
        Console.WriteLine("Sort the list by date ascending:");
        objListOrder.Sort((x, y) => x.OrderDate.CompareTo(y.OrderDate));
    
        foreach (Order o in objListOrder)
            Console.WriteLine("OrderId = " + o.OrderId + " OrderDate = " + o.OrderDate.ToString() + " Quantity = " + o.Quantity + " Total = " + o.Total);
    
        Console.WriteLine("Sort the list by date descending:");
        objListOrder.Sort((x, y) => y.OrderDate.CompareTo(x.OrderDate));
        foreach (Order o in objListOrder)
            Console.WriteLine("OrderId = " + o.OrderId + " OrderDate = " + o.OrderDate.ToString() + " Quantity = " + o.Quantity + " Total = " + o.Total);
    
        Console.WriteLine("Sort the list by OrderId ascending:");
        objListOrder.Sort((x, y) => x.OrderId.CompareTo(y.OrderId));
        foreach (Order o in objListOrder)
            Console.WriteLine("OrderId = " + o.OrderId + " OrderDate = " + o.OrderDate.ToString() + " Quantity = " + o.Quantity + " Total = " + o.Total);
                
        //etc ...
    }
