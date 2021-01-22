    public interface ILongMethod {
      public bool LongMethod( string s, double d, int i, object o, ... );
    }
    
    ...
    public static LongMethodExtensions {
      public bool LongMethod( this ILongMethod lm, string s, double d ) {
        lm.LongMethod( s, d, 0, null );
      }
      ...
    }
