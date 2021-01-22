       public void delete(Page page) 
       {
          try 
          {
             deletePageAndAllReferences(page)
          }
          catch (Exception e) 
          {
             logError(e);
          }
       }
