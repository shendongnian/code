    /// By convention, it's better to use the primitive type string as opposed to the 
    /// wrapping Type String except when making calls to the String static methods
    public static Dictionary<string, List<string>> DirectorySearch(string dir)
        {
            /// I would define a dictionary<string, List<string>> to house the file names
            /// and folder names
            var fileDictionary = new Dictionary<string, List<string>>();
            /// note: variables should be camel case to avoid confusion between them and
            /// classes or properties (which are Pascal Cased)
            try
            {
                var listFiles = new List<string>();
                foreach (string fileName in Directory.GetFiles(dir))
                {
                    listFiles.Add(Path.GetFileName(fileName));
                }
                /// First, we add all the parent directory's files to the dictionary
                fileDictionary.Add(dir, listFiles);
                /// Then we iterate over the subdirectory and add those files to their
                /// own key in the fileDictionary
                foreach (string subDirectory in Directory.GetDirectories(dir))
                {
                    listFiles = new List<string>();
                    foreach (string fileName in Directory.GetFiles(subDirectory))
                    {
                        listFiles.Add(Path.GetFileName(fileName));
                    }
                    fileDictionary.Add(subDirectory, listFiles);
                }
            }
            catch(Exception ex)
            {
                /// Do something with your exception
            }
            return fileDictionary;
        }
