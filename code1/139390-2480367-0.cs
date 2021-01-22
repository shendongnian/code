    public override bool Equals(object o) {
      var other = o as ExampleClass;
      if ( other == null ) { return false; }
      return this.Description == other.Description
        && this.SKU == other.SKU
        && this.Price == other.Price
        && this.Qty == other.Qty;
    }
    public override int GetHashCode() { return 1; }
