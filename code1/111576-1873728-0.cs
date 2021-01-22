    public class MyClass
    {
    	public int OrderID;
        public decimal OrderAmount;
        public DateTime OrderDate;
    }
    
    List<MyClass> list = new List<MyClass>();
    list.Add(new MyClass { OrderID = 1, OrderAmount = 10.50m, OrderDate = new DateTime(2009, 10, 11, 8, 0, 0) });
    list.Add(new MyClass { OrderID = 1, OrderAmount = 11.50m, OrderDate = new DateTime(2009, 10, 11, 10, 0, 0) });
    list.Add(new MyClass { OrderID = 1, OrderAmount = 1.25m, OrderDate = new DateTime(2009, 10, 11, 12, 0, 0) });
    
    list.Add(new MyClass { OrderID = 1, OrderAmount = 100.57m, OrderDate = new DateTime(2009, 10, 12, 09, 0, 0) });
    list.Add(new MyClass { OrderID = 1, OrderAmount = 19.99m, OrderDate = new DateTime(2009, 10, 12, 11, 0, 0) });
    
    var t = from l in list
    	group l by l.OrderDate.Date into g
        let sum = g.Sum(x => x.OrderAmount)
        select new { g.Key, sum , GrandTotal = list.Sum(x => x.OrderAmount) };
