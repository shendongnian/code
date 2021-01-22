    public class FileManager
    {
        private string _fileName;
    
        private int _numberOfTries;
    
        private int _timeIntervalBetweenTries;
    
        private FileStream GetStream(FileAccess fileAccess)
        {
            var tries = 0;
            while (true)
            {
                try
                {
                    return File.Open(_fileName, FileMode.Open, fileAccess, Fileshare.None); 
                }
                catch (IOException e)
                {
                    if (!IsFileLocked(e))
                        throw;
                    if (++tries > _numberOfTries)
                        throw new LanguageWireException("The file is locked too long: " + e.Message, e);
                    Thread.Sleep(_timeIntervalBetweenTries);
                }
            }
        }
    
        private static bool IsFileLocked(IOException exception)
        {
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == 32 || errorCode == 33;
        }
    
        // other code
    
    }
