    public void UpdateEntry(Entity entity)
    {
        var oldEntry = select ....
        var updatedEntity = new Entity{...}; // mix of entity and oldEntry
        _repository.Update<Entity>(updatedEntity);
    }
    
