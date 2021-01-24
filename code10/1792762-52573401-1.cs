    [Test]
    public void Add_AddsEntityToRepository()
    {
        //arrange
        var storageSystem = new StorageSystem {Id = 1, Name = "Storage1"};
        var repo = new Repository<EntityBase>(_context);
        //act
        repo.Add(storageSystem);
        _uow.Complete();
        //assert
        Assert.AreEqual(1, _context.StorageSystems.Count());
    }
