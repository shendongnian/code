    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    class Order 
    {
    	public int Id;
    	public string Name;
    	public Order(int id, string name)
    	{
    		this.Id = id;
    		this.Name = name;
    	}	
    }
    class OrderItem
    {
    	public int Id;
    	public string Name;
    	public int OrderId;
    	public OrderItem(int id, string name, int orderId)
    	{
    		this.Id = id;
    		this.Name = name;
    		this.OrderId = orderId;
    	}
    }
    List<Order> orders = new List<Order>() 
    {
    	new Order(1, "one"), 
    	new Order(2, "two")	
    };
    List<OrderItem> orderItems = new List<OrderItem>()
    {
    	new OrderItem(1, "itemOne", 1),
    	new OrderItem(2, "itemTwo", 1), 
    	new OrderItem(3, "itemThree", 1), 
    	new OrderItem(4, "itemFour", 2), 
    	new OrderItem(5, "itemFive", 2)
    };
    var joined = 
    	from o in orders
    	join oi in orderItems
    	on o.Id equals oi.OrderId into gj // gj means group join and is a collection OrderItem
    	select new { o, gj };
    
    // this is just to write the results to the console
    string columns = "{0,-20} {1, -20}";
    Console.WriteLine(string.Format(columns, "Order", "Item Count"));
    foreach(var j in joined)
    {
    	Console.WriteLine(columns, j.o.Name, j.gj.Count() );
    }
