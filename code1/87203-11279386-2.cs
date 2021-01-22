    using System;
    
    using System.IO;
    
    namespace crmachine.CommonClasses
    {
    
      public static class CRMPath
      {
    
        public static bool IsDirectory(string path)
        {
          if (path == null)
          {
            throw new ArgumentNullException("path");
          }
    
          string reason;
          if (!IsValidPathString(path, out reason))
          {
            throw new ArgumentException(reason);
          }
    
          if (!(Directory.Exists(path) || File.Exists(path)))
          {
            throw new InvalidOperationException(string.Format("Could not find a part of the path '{0}'",path));
          }
    
          return (new System.IO.FileInfo(path).Attributes & FileAttributes.Directory) == FileAttributes.Directory;
        } 
    
        public static bool IsValidPathString(string pathStringToTest, out string reasonForError)
        {
          reasonForError = "";
          if (string.IsNullOrWhiteSpace(pathStringToTest))
          {
            reasonForError = "Path is Null or Whitespace.";
            return false;
          }
          if (pathStringToTest.Length > CRMConst.MAXPATH) // MAXPATH == 260
          {
            reasonForError = "Length of path exceeds MAXPATH.";
            return false;
          }
          if (PathContainsInvalidCharacters(pathStringToTest))
          {
            reasonForError = "Path contains invalid path characters.";
            return false;
          }
          if (pathStringToTest == ":")
          {
            reasonForError = "Path consists of only a volume designator.";
            return false;
          }
          if (pathStringToTest[0] == ':')
          {
            reasonForError = "Path begins with a volume designator.";
            return false;
          }
    
          if (pathStringToTest.Contains(":") && pathStringToTest.IndexOf(':') != 1)
          {
            reasonForError = "Path contains a volume designator that is not part of a drive label.";
            return false;
          }
          return true;
        }
    
        public static bool PathContainsInvalidCharacters(string path)
        {
          if (path == null)
          {
            throw new ArgumentNullException("path");
          }
    
          bool containedInvalidCharacters = false;
    
          for (int i = 0; i < path.Length; i++)
          {
            int n = path[i];
            if (
                (n == 0x22) || // "
                (n == 0x3c) || // <
                (n == 0x3e) || // >
                (n == 0x7c) || // |
                (n  < 0x20)    // the control characters
              )
            {
              containedInvalidCharacters = true;
            }
          }
    
          return containedInvalidCharacters;
        }
    
    
        public static bool FilenameContainsInvalidCharacters(string filename)
        {
          if (filename == null)
          {
            throw new ArgumentNullException("filename");
          }
    
          bool containedInvalidCharacters = false;
    
          for (int i = 0; i < filename.Length; i++)
          {
            int n = filename[i];
            if (
                (n == 0x22) || // "
                (n == 0x3c) || // <
                (n == 0x3e) || // >
                (n == 0x7c) || // |
                (n == 0x3a) || // : 
                (n == 0x2a) || // * 
                (n == 0x3f) || // ? 
                (n == 0x5c) || // \ 
                (n == 0x2f) || // /
                (n  < 0x20)    // the control characters
              )
            {
              containedInvalidCharacters = true;
            }
          }
    
          return containedInvalidCharacters;
        }
    
      }
    
    }
