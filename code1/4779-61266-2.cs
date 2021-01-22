    public string ToString()
    {
         Debug.Assert(Name != null);
         if ( Name == null )
         {
              throw new InvalidOperationException("Name is null");
         }
         return Name;
    }
