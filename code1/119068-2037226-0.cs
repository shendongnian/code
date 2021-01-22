    public static <T> T resolve(Class<T> type) {
      try {
        return type.newInstance();
      } catch(Exception e) {
        // deal with the exceptions that can happen if 
        // the type doesn't have a public default constructor
        // (something you could write as where T : new() in C#)
      }
    }
