    var newOrder = new Order();
    var listsauces = new List<OrderSauceItem>();
    listsauces.Add(new OrderSauceItem {SauceId = ctx.Sauces.Where(x => x.Id == 3).FirstOrDefault(), Quantity = 1 });
    
    newOrder.Sauces = listsauces;
    
    var listPizzas = new List<OrderPizzaItem>();
    listPizzas.Add(new OrderPizzaItem {  PizzaId = ctx.Pizzas.Where(x => x.Id == 1).FirstOrDefault(), Quantity = 2 });
                    listPizzas.Add(new OrderPizzaItem {PizzaId = ctx.Pizzas.Where(x => x.Id == 2).FirstOrDefault(), Quantity = 2 });
    
    newOrder.Pizzas = listPizzas;
    
    ctx.Orders.Add(newOrder);
    ctx.SaveChanges();
