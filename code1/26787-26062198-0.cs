    using System;
    using System.IO;
    //..
    
           public static bool ValidateFilePath(string path,bool RequireDirectory,bool IncludeFileName,bool RequireFileName=false)
        {
            if (string.IsNullOrEmpty(path)) {return false;}
            string root = null; ;
            string directory=null;
            string filename=null;
            try
            {
                //throw ArgumentException	- The path parameter contains invalid characters, is empty, or contains only white spaces.
                root = Path.GetPathRoot(path);
                //throw ArgumentException	- path contains one or more of the invalid characters defined in GetInvalidPathChars.
                //    -or- String.Empty was passed to path.
                directory = Path.GetDirectoryName(path);
                //path contains one or more of the invalid characters defined in GetInvalidPathChars
                if (IncludeFileName) { filename = Path.GetFileName(path); }
            }
            catch (ArgumentException)
            {
                return false;
            }
            //null if path is null, or an empty string if path does not contain root directory information
            if (String.IsNullOrEmpty(root)){return false;}
            //null if path denotes a root directory or is null. Returns String.Empty if path does not contain directory information
            if (String.IsNullOrEmpty(directory)) { return false; }
            if (RequireFileName)
            {
                //f the last character of path is a directory or volume separator character, this method returns String.Empty
                if (String.IsNullOrEmpty(filename)) { return false; }
                //check for illegal chars in filename
                if (filename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0){ return false;}
            }
            return true;
        }
