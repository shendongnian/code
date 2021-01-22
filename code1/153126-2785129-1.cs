    class FileInfo {
      public int FileSizeBytes {get;set;}
      public int FileSizeFormatted {
       get{
         //Using general number format, will put commas between thousands in most locales.
         return FileSizeBytes.ToString("G");
       }
      }
    }
