     class Program
    {
        
        /// <summary>
        /// Tests if can read files and if any are present
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        private genericResponse check_canRead(string dirPath)
        {
            try
            {
                IEnumerable<string> files = Directory.EnumerateFiles(dirPath);
                if (files.Count().Equals(0))
                    return new genericResponse() { status = true, idMsg = genericResponseType.NothingToRead };
                                
                return new genericResponse() { status = true, idMsg = genericResponseType.OK };
            }
            catch (DirectoryNotFoundException ex)
            {
                return new genericResponse() { status = false, idMsg = genericResponseType.ItemNotFound };
            }
            catch (UnauthorizedAccessException ex)
            {
                return new genericResponse() { status = false, idMsg = genericResponseType.CannotRead };
            }
        }
        /// <summary>
        /// Tests if can wirte both files or Directory
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        private genericResponse check_canWrite(string dirPath)
        {
            try
            {
                string testDir = "__TESTDIR__";
                Directory.CreateDirectory(string.Join("/", dirPath, testDir));
                Directory.Delete(string.Join("/", dirPath, testDir));
                string testFile = "__TESTFILE__.txt";
                try
                {
                    TextWriter tw = new StreamWriter(string.Join("/", dirPath, testFile), false);
                    tw.WriteLine(testFile);
                    tw.Close();
                    File.Delete(string.Join("/", dirPath, testFile));
                    return new genericResponse() { status = true, idMsg = genericResponseType.OK };
                }
                catch (UnauthorizedAccessException ex)
                {
                    return new genericResponse() { status = false, idMsg = genericResponseType.CannotWriteFile };
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return new genericResponse() { status = false, idMsg = genericResponseType.CannotWriteDir };
            }
        }
    }
    public class genericResponse
    {
        public bool status { get; set; }
        public genericResponseType idMsg { get; set; }
        public string msg { get; set; }
    }
    public enum genericResponseType
    {
        NothingToRead = 1,
        OK = 0,
        CannotRead = -1,
        CannotWriteDir = -2,
        CannotWriteFile = -3,
        ItemNotFound = -4
    }
