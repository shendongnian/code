    var cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();
    var stockList = uow.Repository<Product>().GetAll().ToList(); // the type is List<Product>
    foreach (var item in stockList)
    {
        cart.Add(new CartVM() 
                 {
                     // other properties
                     Instock = item.InStock 
                 });
    }
    return cart;
