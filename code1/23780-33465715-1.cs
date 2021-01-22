        const char PATH_DELIMITER = '/';
        /// <summary>
        /// Combines a path and a relative path.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="relative"></param>
        /// <returns></returns>
        public static string Combine(string path, string relative) 
        {
            if(relative == null)
                relative = String.Empty;
            
            if(path == null)
                path = String.Empty;
            if(relative.Length == 0 && path.Length == 0)
                return String.Empty;
            if(relative.Length == 0)
                return path;
            if(path.Length == 0)
                return relative;
            path = path.Replace('\\', PATH_DELIMITER);
            relative = relative.Replace('\\', PATH_DELIMITER);
            return path.TrimEnd(PATH_DELIMITER) + PATH_DELIMITER + relative.TrimStart(PATH_DELIMITER);
        }
