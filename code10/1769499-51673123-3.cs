    var query = OrderItems(items)
        .Skip(pageIndex * pageSize)
        .Take(pageSize)
        .Select(item => new ItemViewModel
        {
            Id = item.Id,
            Description = item.Description,
             ItemPriority = item.Priority.Description(),
        })
        .Convert();
