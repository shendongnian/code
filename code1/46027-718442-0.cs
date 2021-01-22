    public class PathHelper
    {
      static string _sBasePath;
      static PathHelper()
      {
         _sBasePath = Properties.Settings.Default.BasePath;
      }
    
      static string GetTempSavePath(string sUserId)
      {
         // dummy logic to compute return value, replace to taste
         return Path.Combine(_sBasePath, sUserId.Substring(0, 4));
      }
    }
