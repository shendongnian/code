    var myDtos = context.MoyObjects.Where(x => x.IsActive && x.ParentId == parentId)
      .ToList()
      .Select( x => new ObjectDto
      {
        Id = x.Id,
        Name = x.FirstName + " " + x.LastName,
        Balance = calculateBalance(x.OrderItems.ToList()),
        Children = x.Children.ToList()
          .Select( c => new ChildDto  
          {
            Id = c.Id,
            Name = c.Name
          }).ToList()
      }).ToList();
