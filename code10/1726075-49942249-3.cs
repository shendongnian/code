    public static void WriteAllLines(String path, IEnumerable<String> contents)
    { 
      ...
      InternalWriteAllLines(new StreamWriter(path, false, StreamWriter.UTF8NoBOM), contents);
    }
