    class FileInfo {
      public int FileSizeBytes {get;set;}
      public int FileSizeFormatted {
       get{
         return string.Format("{0}", FileSizeBytes);
       }
      }
    }
