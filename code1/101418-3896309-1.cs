    class MyObj : IEquatable<MyObj> {
      
      public static bool operator ==( MyObj left, MyObj right ) {
        return EqualityComparer<MyObj>.Default.Equals( left, right );
      }
      
      public static bool operator !=( MyObj left, MyObj right ) {
        return !EqualityComparer<MyObj>.Default.Equals( left, right );
      }
      
      public override bool Equals( object obj ) {
        return this.Equals( obj as MyObj );
      }
      
      public bool Equals( MyObj other ) {
        return !object.ReferenceEquals( other, null )
            && obj.FieldOne == this.FieldOne
            && obj.FieldTwo == this.FieldTwo
            && ...
            ;
      }
      
      ...
      
    }
