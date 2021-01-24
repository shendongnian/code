    using (var context = new StoreContext())
    {
      var userViewModel = context.Users.Where(x => x.UserId == userId)
        .Select(x => new UserViewModel 
        {
          UserId = x.UserId,
          UserName = x.UserName,
          Orders = x.Orders
            .Where(o => o.IsActive)
            .Select( o => new OrderViewModel
            {
              OrderId = o.OrderId,
              OrderNumber = o.OrderNumber
              Price = o.OrderItems.Sum(i => i.Price)
            }).ToList()
         }).SingleOrDefault();
       return userViewModel;
    }
