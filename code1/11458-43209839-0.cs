        /// <summary>
        /// Finds files for the given glob path. It supports ** * and ? operators. It does not support !, [] or ![] operators
        /// </summary>
        /// <param name="path">the path</param>
        /// <returns>The files that match de glob</returns>
        private ICollection<FileInfo> FindFiles(string path)
        {
            List<FileInfo> result = new List<FileInfo>();
            //The name of the file can be any but the following chars '<','>',':','/','\','|','?','*','"'
            const string folderNameCharRegExp = @"[^\<\>:/\\\|\?\*" + "\"]";
            const string folderNameRegExp = folderNameCharRegExp + "+";
            //We obtain the file pattern
            string filePattern = Path.GetFileName(path);
            List<string> pathTokens = new List<string>(Path.GetDirectoryName(path).Split('\\', '/'));
            //We obtain the root path from where the rest of files will obtained 
            string rootPath = null;
            bool containsWildcardsInDirectories = false;
            for (int i = 0; i < pathTokens.Count; i++)
            {
                if (!pathTokens[i].Contains("*")
                    && !pathTokens[i].Contains("?"))
                {
                    if (rootPath != null)
                        rootPath += "\\" + pathTokens[i];
                    else
                        rootPath = pathTokens[i];
                    pathTokens.RemoveAt(0);
                    i--;
                }
                else
                {
                    containsWildcardsInDirectories = true;
                    break;
                }
            }
            if (Directory.Exists(rootPath))
            {
                //We build the regular expression that the folders should match
                string regularExpression = rootPath.Replace("\\", "\\\\").Replace(":", "\\:").Replace(" ", "\\s");
                foreach (string pathToken in pathTokens)
                {
                    if (pathToken == "**")
                    {
                        regularExpression += string.Format(CultureInfo.InvariantCulture, @"(\\{0})*", folderNameRegExp);
                    }
                    else
                    {
                        regularExpression += @"\\" + pathToken.Replace("*", folderNameCharRegExp + "*").Replace(" ", "\\s").Replace("?", folderNameCharRegExp);
                    }
                }
                Regex globRegEx = new Regex(regularExpression, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
                string[] directories = Directory.GetDirectories(rootPath, "*", containsWildcardsInDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                foreach (string directory in directories)
                {
                    if (globRegEx.Matches(directory).Count > 0)
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                        result.AddRange(directoryInfo.GetFiles(filePattern));
                    }
                }
           
            }
            return result;
        }
