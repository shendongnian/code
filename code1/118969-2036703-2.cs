    var myObjects = new []{
        new { Id = Guid.NewGuid(), Title = "Some Title", Description = string.Empty },
        new { Id = Guid.NewGuid(), Title = "Another Title", Description = string.Empty },
        new { Id = Guid.NewGuid(), Title = "Number 3", Description = "Better than No2, but not much" }
    }
    foreach(var myObject in myObjects) {
        DoSomeThingWith(myObject.Title);
    }
