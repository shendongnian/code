    public static void ProcessDirectory(string directoryPath)
        {
            IDictionary<string,string> prefixDictionary = new Dictionary<string, string>();
    
            if (Directory.Exists(directoryPath))
            {
                foreach(string filePath in Directory.GetFiles(directoryPath))
                {
                    string fileName = Path.GetFileName(filePath);
                    string fileDirectory = Path.GetDirectoryName(filePath);
                    if (fileName.Length>=3)
                    {                        
                        string prefix = fileName.Substring(0, 3);
                        string rightPart = fileName.Substring(3, fileName.Length - 3);
                        if (!prefixDictionary.ContainsKey(prefix))
                        {
                            prefixDictionary[prefix] = rightPart;
                        }
                        else
                        {
                            string fileToArchive = null;
                            string storedRightPart = prefixDictionary[prefix];
                            // using string compare, but you could test file date or
                            // or parse the right part as a number if you only cared about
                            // files with numbers on the right.
                            if (String.Compare(storedRightPart,rightPart)<0)
                            {
                                prefixDictionary[prefix] = rightPart;
                                fileToArchive = Path.Combine(fileDirectory,prefix+storedRightPart);
                            }
                            else
                            {
                                fileToArchive = filePath;
                            }
    
                            if (fileToArchive != null)
                            {
                                // perform the archive here
                            }
                        }
                    }
                }
            }
        }
