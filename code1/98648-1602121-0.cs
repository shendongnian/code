    MainsDataContext dx = null;    
    try
        {
             dx = new MainsDataContext();
           
            Main m = dx.Main.SingleOrDefault(s => s.Name == name);
            
            if ( m == null)
            { 
               Guid g = Guid.NewGuid();
    
               m = new Main 
              {
                  Name = name,
                  ID = g
              };
              
             dx.Mains.InsertOnSubmit(m);
             dx.SubmitChanges();
    
            }
    
            return m.ID;
        }
        catch (Exception ex)
        {
            // handle this
        }
        finally
        {
           if(dx != null)
              dx.Dispose();
        }
