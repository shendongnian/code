    var query = MyDataContext.Parents.Select(parent => new PClass
    {
        Id = parent.Id,
        Children = parent.Children.Select(child => new ChClass
        {
            Id = child.Id,
            // ParentId = y.ParentId, Useless, you know it has the same value as Id
            // Parent = ... useless, you know it has the same value as the parent
            // that you are creating.
        })
        .ToList(),
    });
