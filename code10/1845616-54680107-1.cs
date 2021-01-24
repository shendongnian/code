    public int UpdateRank(Guid localId, int rank, Guid entityTypeId)
    {            
        var result = _dbContext.EntityAttribute.Single(en => en.ParentGuid == localId 
            && en.EntityAttributeTypeId == entityTypeId);
        var myInt = _dbContext.MyInts.Single(x => x.MyIntId == rank);
        result.MyInt = myInt;
        return _dbContext.SaveChanges();            
    }
