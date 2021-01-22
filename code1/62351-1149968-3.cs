    public override bool Equals( object obj ) {
      return Equals( obj as TwoDPoint );
    }
    
    public bool Equals( TwoDPoint other ) {
      // Note: null check not needed for value types.
      return !object.ReferenceEquals( other, null )
          && EqualityComparer<int>.Default.Equals( this.X, other.X )
          && EqualityComparer<int>.Default.Equals( this.Y, other.Y );
    }
    
    public static bool operator ==( TwoDPoint left, TwoDPoint right ) {
      // System.Collections.Generic.EqualityComparer<T> will perform the null checks 
      //  on the operands, and will call the Equals overload if necessary.
      return EqualityComparer<TwoDPoint>.Default.Equals( left, right );
    }
    
    public static bool operator !=( TwoDPoint left, TwoDPoint right ) {
      return !EqualityComparer<TwoDPoint>.Default.Equals( left, right );
    }
