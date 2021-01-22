    public string ToString()
    {
         if ( Name == null )
         {
              throw new InvalidOperationException("Name is null");
         }
         return Name;
    }
