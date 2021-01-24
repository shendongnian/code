    // Delete
    using (DataControllers.RIT_Allocation_Entities RAEE = new DataControllers.RIT_Allocation_Entities())
    {
      var entry = RAEE.Entry(jsmodel2);
    
      if (entry.State == EntityState.Detached)
      {
        RAEE.Job_Service.Attach(jsmodel2);
        RAEE.Job_Service.Remove(jsmodel2);
        RAEE.SaveChanges();
        populateServiceDetailsGrid();
      }
    }
