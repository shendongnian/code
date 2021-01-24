    List<NewObject> newObjects = myObject.Items.Select(i => new NewObject
    {
        Item = i,
        Id = myObject.Id
    }).ToList();
