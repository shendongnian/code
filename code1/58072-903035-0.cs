    public static class Extension {
      public static void Method(this ParentClass p) { 
        var c = p as ChildAClass;
        if ( c != null ) {
          Method(c);
        } else {
          // Do parentclass action
        }
      }
      public static void Method(this ChildAClass c) {
        ...
      }
    }
