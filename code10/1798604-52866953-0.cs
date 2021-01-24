     var pipeline = collection.Aggregate()
                             .Match(up => up.UserID == userId)
                             .Project(up => new { DemRole = up.DemRole.Where(c => c.Status== true) }).ToList();
                  // .Project(dem => dem.DemRole.Where(c => c.Status == true));//.ToList();
            
           
            foreach(var pipe in pipeline)
            {
                return pipe.DemRole.ToList();
                
            }
