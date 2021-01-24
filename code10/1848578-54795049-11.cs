    public string Find(long id, string pathSoFar)
    {
        if (pathSoFar == null)
        {
           pathSoFar = Name;
        }
        else
        {
           pathSoFar = pathSoFar + "/" + Name;
        }
        if ( Id == id)
        {
           return pathSoFar;
        }
        else
        {
          foreach( var entry in Categories)
          {
             string path = entry.Find(id, pathSoFar + "/");
             if( path != null )
             {
                 return path;
             }
          }
          return null;
        }
    }
