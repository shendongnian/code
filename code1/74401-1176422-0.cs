    public void TestGivenFiles(List<string> listFiles)
    {
          List<FileStream> replaceAbleFileStreams = GetFileStreams(listFiles);
            Console.WriteLine("files Received = " + replaceAbleFileStreams.Count);
            foreach (FileStream fileStream in replaceAbleFileStreams)
            {
                // Replace the files the way you want to.
                fileStream.Close();
            }
        }
        public List<FileStream> GetFileStreams(List<string> listFilesToReplace)
        {
            List<FileStream> replaceableFiles = new List<FileStream>();
            foreach (string sFileLocation in listFilesToReplace)
            {
                FileAttributes fileAttributes = File.GetAttributes(sFileLocation);
                if ((fileAttributes & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                { // Make sure that the file is NOT read-only
                    try
                    {
                        FileStream currentWriteableFile = File.OpenWrite(sFileLocation);
                        replaceableFiles.Add(currentWriteableFile);
                    }
                    catch 
                    {
                        Console.WriteLine("Could not get Stream for '" + sFileLocation+ "'. Possibly in use");
                    }
                }
            }
            return replaceableFiles;
        }
