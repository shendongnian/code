    public void UpdateEntry(Entity entity)
    {
        var oldEntry = select ....
        
        oldEntry.CreationDate = entity.CreationDate {...}
        _repository.Update<Entity>(oldEntry);
    }
   
