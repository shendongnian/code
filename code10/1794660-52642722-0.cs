    public IQueryable <fruits> GetAllfruitsIDs() {
          return fruits.AsQueryable();
        }
        
        var data = GetAllfruitsIDs();
    
       // Or u can use this :
         public IEnumerable<fruits> GetAllfruitsIDs() {
                  return fruits.AsQueryable().ToList;
                }
                
            var data = GetAllfruitsIDs();
