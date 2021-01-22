    public static class GlobalSettings {
      private static string s_path;
      public static string Path { get { return s_path; } }
      public static void UpdatePath(string path) {
        if ( s_path != null || path == null ) { throw ... }
        s_path = path;
      }
    }
