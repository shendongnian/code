    public IQueryable<Part> SearchForParts(string[] query)
    {
        return from part in db.Parts
               where Search(part.Name,query)
               select part;
    }
    public bool Search(string partName,string[] query)
    {
        for (int i = 0; i < query.Length; i++)
        {
            if(partName.Contains(query[i]))
               return true;
        }
        return false;
    }
