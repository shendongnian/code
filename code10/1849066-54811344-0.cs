    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
    }
    public class OrderEvent
    {
        public int OrderId { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
    }
    public static void Main(string[] args) // Here our Exe-Args are delivered to our program..
    {
        List<Order> orders = new List<Order>()
        {
            new Order() { OrderId = 1, OrderName = "One" }
        };
        List<OrderEvent> orerEvents = new List<OrderEvent>()
        {
            new OrderEvent() { OrderId = 1, EventName = "EventTwo", Date = DateTime.Now.AddHours(-1) },
            new OrderEvent() { OrderId = 1, EventName = "EventOne", Date = DateTime.Now },
            new OrderEvent() { OrderId = 1, EventName = "EventThree", Date = DateTime.Now.AddHours(-2) },
            new OrderEvent() { OrderId = 2, EventName = "EventX", Date = DateTime.Now },
        };
        var tmp = orders.GroupJoin( // Join something to our orders
                orerEvents, // join all events
                o => o.OrderId, // key of our order
                e => e.OrderId, // foreign-key to order in our event
                (o, es) => // lambda-expression "selector". One order "o" and multiple events "es"
                es.OrderByDescending(e => e.Date) // We order our events
                .Select(s => new // we build a new object
                {
                    OrderId = o.OrderId,
                    OrderName = o.OrderName,
                    RecentEvent = s.EventName
                }).First()); // we choose the object with biggest date (first after orderDesc)
        foreach (var item in tmp)
        {
            Console.WriteLine(item.OrderId + ", " + item.OrderName+ ", " + item.RecentEvent);
        }
    }
