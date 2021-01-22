    public IList<Forum> AllowedForums
    {
       get
       {
          var result = new List<Forum>();
          foreach(var relationShip in this.AllowedForumsRelationship)
          {
             result.Add(relationShip.Forum);
             return result;
          }
       }
    }
