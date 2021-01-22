    Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
          if (string.IsNullOrWhiteSpace(path) || path.Length < 3)
          {
            return false;
          }
    
          if (!driveCheck.IsMatch(path.Substring(0, 3)))
          {
            return false;
          }
          string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
          strTheseAreInvalidFileNameChars += @":/?*" + "\"";
          Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
          if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
          {
            return false;
          }
    
          DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetFullPath(path));
          try
          {
            if (!directoryInfo.Exists)
            {
              directoryInfo.Create();
            }
          }
          catch (Exception ex)
          {
            if (Log.IsErrorEnabled)
            {
              Log.Error(ex.Message);
            }
            return false;
          }`enter code here`
    
          return true;
        }
