    void SomeMethod(SampleEntities entities){
    
      var do_dispose = false;
      if(entities == null) { entities = new SampleEntities();
      entities.Connection.Open(); 
      do_dispose = true; }
    
      try{
        // do with entity object...
      }
      finally{
        if(do_dispose && entities != null){
          entities.Dispose();
        }
      }
    
    }
