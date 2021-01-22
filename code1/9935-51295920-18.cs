    Class SomeType { 
      public void Method() { .. }
    }
    
    sealed Class SomeTypeTypeDef {
      public SomeTypeTypeDef(SomeType composed) { this.Composed = composed; }
    
      private SomeType Composed { get; }
    
      public override string ToString() => Composed.ToString();
      public override int GetHashCode() => HashCode.Combine(Composed);
      public override bool Equals(object obj) { var o = obj as SomeTypeTypeDef; return o is null ? false : Composed.Equals(o.Composed); }
      public bool Equals(SomeTypeTypeDefo) => object.Equals(this, o);
      // proxy the methods we want
      public void Method() => Composed.Method();
    }
