    public override bool Equals(object obj) {
       var myClass = obj as MyClass;
       if (myClass != null) {
          // Order these by the most different first.
          // That is, whatever value is most selective, and the fewest
          // instances have the same value, put that first.
          return this.Id == myClass.Id
             && this.Name == myClass.Name
             && this.Quantity == myClass.Quantity
             && this.Color == myClass.Color;
       } else {
          // This may not make sense unless GetHashCode refers to `base` as well!
          return base.Equals(obj);
       }
    }
    public override int GetHashCode() {
       int hash = 19;
       unchecked { // allow "wrap around" in the int
          hash = hash * 31 + this.Id; // assuming integer
          hash = hash * 31 + this.Name.GetHashCode();
          hash = hash * 31 + this.Quantity; // again assuming integer
          hash = hash * 31 + this.Color.GetHashCode();
       }
       return hash;
    }
