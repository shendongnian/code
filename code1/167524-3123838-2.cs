    public List<string> TagNameList (int objectId)
    {
        return db.Tags.Where(ob => ob.Id == objectId)
                      .SelectMany(ob => ob.Tags)
                      .Select(tag => tag.Name)
                      .ToList();  
    }
