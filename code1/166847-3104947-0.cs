    public class SanitizeFilenames
    {
        public List<string> FileCleanUp(List<string> filenames)
        {
            var cleanedFileNames = new List<string>();
            var invalidChars = Path.GetInvalidFileNameChars();
            foreach(string file in filenames)
            {
                if(file.IndexOfAny(invalidChars) != -1)
                {
                    // clean the file name and add it to the cleanedFileNames list
                }
                else 
                {
                    // nothing to clean here
                    cleanedFileNames.Add(file);
                }
            }
            
            return cleanedFileNames;
        }
    }
