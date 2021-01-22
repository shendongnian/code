    public static void ConvertFile(Type type) {
      if ( !typeof(IFileType).IsAssignableFrom(type)) {
        throw new ArgumentException("type");
      }
      ...
    }
