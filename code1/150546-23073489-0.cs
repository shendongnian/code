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
    	public string Name;
    	public int OrderId;
    	public OrderItem(string name, int orderId)
    	{
    	    this.Name = name;
            this.OrderId = orderId;
    	}
    }
    List<Order> orders = new List<Order>() 
    {
    	new Order(1, "one"), new Order(2, "two")	
    };
    List<OrderItem> orderItems = new List<OrderItem>()
    {
    	new OrderItem("itemOne", 1),
    	new OrderItem("itemTwo", 1), 
    	new OrderItem("itemThree", 1), 
    	new OrderItem("itemFour", 2), 
    	new OrderItem("itemFive", 2)
    };
    var joined = 
    	from Order in orders
    	join OrderItem in orderItems
    	on Order.Id equals OrderItem.OrderId
    	select new { Order, OrderItem };
    
    string columns = "{0,-20} {1, -20}";
    Console.WriteLine(string.Format(columns, "Order", "Item"));
    foreach(var j in joined)
    {
    	Console.WriteLine(columns, j.Order.Name, j.OrderItem.Name);
    }
