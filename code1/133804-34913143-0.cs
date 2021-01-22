    public override bool Equals(object obj)
    {
       var myClass = obj as MyClass;
       if (null != myClass)
       {
          // Order these by the most different first.
          // That is, whatever value is most selective, and the fewest
          // instances have the same value, put that first.
          return this.Id == newObj.Id
             && this.Name == newObj.Name
             && this.Quantity = newObj.Quantity
             && this.Color = newObj.Color;
       }
       else
       {
          // Not sure this makes sense!
          return base.Equals(obj);
       }
    }
    public override int GetHashCode()
    {
       int hash = 19;
       unchecked { // allow "wrap around" in the int
          hash = hash * 31 + this.Id; // assuming integer
          hash = hash * 31 + this.Name.GetHashCode();
          hash = hash * 31 + this.Quantity; // again assuming integer
          hash = hash * 31 + this.Color.GetHashCode();
       }
       return hash;
    }
