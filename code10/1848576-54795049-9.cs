    public string Find(long id)
    {
       if( Id == id ) 
       {
        return GetPath(); //<-- we need to code this next. 
       }
       else
       {
          foreach( var entry in Categories)
          {
             string path = entry.Find(id);
             if( path != null )
             {
                 return path;
             }
          }
          return null;
       }
    }
