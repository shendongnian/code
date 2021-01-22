    class Competition
    { 
       int ID { get; set;}
       int ParentID { get; set; }
       IEnumerable<Competition> Children { get; set; } 
    }
    
    public IEnumerable<Competition> GetChildren(
       IEnumerable<Competition> competitions, int parentID)
    {
       IEnumerable<Competition> children =
          competitions.Where(c => c.ParentID == parentID);
    
       if (children.Count() == 0)
          return null; 
    
       return children.Select(
          c => new Competition { ID = c.ID, Children = GetChildren(c.ID) };
    }
