    public bool Equals(T other) 
    {
      if (other == null) 
         return false;
      return (this.Id == other.Id);
    }
    public override bool Equals(Object obj)
    {
      if (obj == null) 
         return false;
      T tObj = obj as T;  // The extra cast
      if (tObj == null)
         return false;
      else   
         return this.Id == tObj.Id;
    }
