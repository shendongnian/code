	public class OrderPizzaItem 
	{
		public Pizza Pizza { get; set; }
		public int Quantity { get; set; }
	}
	public class OrderSauceItem 
	{
		public Pizza Pizza { get; set; }
		public int Quantity { get; set; }
	}
	public class Order
	{
	    public Order()
	    {
	        Sauces = new List<OrderSauceItem>();
	        Pizzas = new List<OrderPizzaItem>();
	    }
	    public int OrderId { get; set; }
	    public virtual ICollection<OrderSauceItem> Sauces { get; set; }
	    public virtual ICollection<OrderPizzaItem> Pizzas { get; set; }
	}
	var newOrder = new Order();
	var listsauces = new List<OrderSauceItem>();
	listsauces.Add(new OrderSauceItem { Sauce = ctx.Sauces.Where(x => x.Id == 3).FirstOrDefault(), Quantity = 2});
	newOrder.Sauces = listsauces;
	var listPizzas = new List<OrderPizzaItem>();
	listPizzas.Add(new OrderPizzaItem { Pizza = ctx.Pizzas.Where(x => x.Id == 1).FirstOrDefault(), Quantity = 2});
	listPizzas.Add(new OrderPizzaItem { Pizza = ctx.Pizzas.Where(x => x.Id == 2).FirstOrDefault(), Quantity = 1})
	newOrder.Pizzas = listPizzas;
	ctx.Orders.Add(newOrder);
	ctx.SaveChanges();
