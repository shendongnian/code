    public class Utility
    {
         public static string GetFileName(string grpID)
         {
                string filenameUNC = "\\\\" + "localhost" + "\\AgentShare\\";
        
                string realPath = GetPath(filenameUNC);
        
                return realPath;
         }
    }
