    var book = new Book{ Id = 123, Title = "Hello World", Price = 42.42M };
	var cart = new CartItem{ Book = book, Quantity = 2 };
	var order = new Order{OrderNumber = 66};
	order.CartItems = new List<CartItem>(); 
	order.CartItems.Add(cart);
	
	Console.WriteLine();
	
	foreach(var item in order.CartItems)
	{
		Console.WriteLine("Book ID: " + item.Book.Id);
		Console.WriteLine("Book Title: " + item.Book.Title);
		Console.WriteLine("Book Price: " + item.Book.Price);
		Console.WriteLine("Quantity: " + item.Quantity);
		Console.WriteLine("SubTotal: " + item.Quantity * item.Book.Price);
		order.OrderTotal += item.Quantity * item.Book.Price;
	}	
	
	Console.WriteLine("Order Total: " + order.OrderTotal);
