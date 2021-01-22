    public static class CsvWriter
    {
       private static StreamWriter _writer = new StreamWriter(...);
     
       public static  StreamWriter Writer 
       {
          get { return _writer; }
       }
    }
