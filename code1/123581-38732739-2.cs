    public partial class Foo {
      
        public static operator==(Foo x, Foo y) {
           if( x == null && y != null ) return false;
           return x.Equals( y );
       }
    }
    public partial class Bar {
       public static operator==(Bar x, Bar y) {
           if( x == null && y != null ) return false;
           return x.Equals( y );
       }
    }
