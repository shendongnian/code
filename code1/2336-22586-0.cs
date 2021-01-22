    public static class Try {
        public static List<string> This( Action action ) {
          var errors = new List<string>();
          try {
            action();
          }
          catch ( SpecificException e ) {
            errors.Add( "Something went 'orribly wrong" );
          }
          catch ( ... )
          // ...
         return errors;
        }
    }
