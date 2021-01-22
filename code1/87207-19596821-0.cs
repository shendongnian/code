        bool IsPathDirectory(string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            path = path.Trim();
            if (Directory.Exists(path)) 
                return true;
            if (File.Exists(path)) 
                return false;
            // neither file nor directory exists. guess intention
            // if has trailing slash then it's a directory
            if (new[] {"\\", "/"}.Any(x => path.EndsWith(x)))
                return true; // ends with slash
             
            // has if extension then its a file; directory otherwise
            return string.IsNullOrWhiteSpace(Path.GetExtension(path));
        }
