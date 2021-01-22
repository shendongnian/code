    public static class Extensions {
      public static bool contains(this string source, bool ignoreCase) {... }
    }
    
    void Example {
      string str = "aoeeuAOEU";
      if ( str.contains("a", true) ) { ... }
    }
