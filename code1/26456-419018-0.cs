    public class Matcher
    {
      private int totalFileCount;
      private int matchedCount;
      private DateTime start;
      private int lineCount;
      private DateTime stop;
    
      public IEnumerable<string> Match()
      {
         return GetMatchedFiles();
         System.Console.WriteLine(string.Format(
           "Found {0} matches in {1} matching files." + 
           " {2} total files scanned in {3}.", 
           lineCount, matchedCount, 
           totalFileCount, (stop-start).ToString());
      }
    
      private IEnumerable<File> GetMatchedFiles(string pattern)
      {
         foreach(File file in SomeFileRetrievalMethod())
         {
            totalFileCount++;
            if (MatchPattern(pattern,file.FileName))
            {
              matchedCount++;
              yield return file;
            }
         }
      }
    }
