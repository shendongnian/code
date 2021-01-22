       public override void Update() 
       {
             DateTime originalUpdatedAt = UpdatedAt;
             try 
             {
                UpdatedAt = DateTime.UtcNow;  // Assuming you're using UTC timestamps (which I'd recommend)                     
                base.Update(); 
             }
             catch  // Don't worry, you're rethrowing so nothing will get swallowed here.
             {
                UpdatedAt = originalUpdatedAt;
                throw;
             }
       }
