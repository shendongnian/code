    public IQueryable<Part> SearchForParts(string[] query)
    {
      var q = db.Parts.AsQueryable(); 
    
      foreach (var qs in query)
      { 
        var likestr = string.Format("%{0}%", qs);
        q = q.Where(x => SqlMethods.Like(x.partName, likestr));
      }
    
      return q;
    }
