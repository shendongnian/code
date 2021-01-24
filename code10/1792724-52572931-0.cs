    public class SearchForFiles
    {
         public SearchForFile(List<string> searchFolder, List<string> fileType, bool searchSubFolder)
         {
             _searchSubFolder = searchSubFolder;
             FindFiles(searchFolder, fileType, searchSubFolder);
         }
   
         public SearchForFiles(string searchFolder, string fileType):this(new List<string>(){searchFolder}, new List<string>(){fileType}, false)
         {
         }
         public SearchForFiles(string searchFolder):this(new List<string>(){searchFolder}, new List<string>(), false)
         {
         }
