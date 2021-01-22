    public List<string> TagNameList (int objectId)
    {
        return db.Tags.Where(ob => ob.Id == objectId)
                      .Select(tag => tag.Name)
                      .ToList();  
    }
