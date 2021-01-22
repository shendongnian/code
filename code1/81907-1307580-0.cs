    public override bool Equals(Object obj)
    {
       if (obj == null) return base.Equals(obj);
 
       if (! (obj is Person))
          return false; // Instead of throw new InvalidOperationException
       else
          return Equals(obj as Person);   
    }
