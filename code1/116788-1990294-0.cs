    private void CreateAddress(BizObjects.Address address)
    {
        var entity = new EntityFramework.Address();
    
        entity.Line1 = address.Line1;
        entity.Line2 = address.Line2;
        entity.City = address.City;
        entity.State = address.State;
        entity.ZipCode = address.ZipCode;
    
        _entities.AddToAddress(entity);
        _entities.SaveChanges();
    
        int id = _entity.ID; // *****
    }
