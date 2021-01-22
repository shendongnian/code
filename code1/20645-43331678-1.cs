    public int InsertEntity(Entity factor)
    {
        Db.Entities.Add(factor);
        Db.SaveChanges();
        var id = factor.id;
        return id;
    }
