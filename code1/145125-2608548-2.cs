    void SomeMethod(SampleEntities entities){
    
      var do_dispose = false;
      try{
      if(entities == null) { entities = new SampleEntities();
      entities.Connection.Open(); 
      do_dispose = true; }
    
      
        // do with entity object...
      }
      finally{
        if(do_dispose && entities != null){
          entities.Dispose();
        }
      }
    
    }
