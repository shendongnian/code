    using System.IO;
    using System.Runtime.InteropServices;
    internal static class Helper
    {
        internal static bool CanReadFile(string filePath) {
            //Try-Catch so we dont crash the program and can check the exception
            try
            {
                //We want to use "using" because FileStream implements IDisposable and we dont want 
                //to get into a heap exhaustion situation when too many handles are left undisposed
                using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    //Don't forget to close the stream, especially if we wish to use this file later (I know the "using" does it but we wish to be explicit when we encountered errors around this!)
                    if (stream != null)
                        stream.Close();
                }
            }
            catch (IOException ex) {
                //THE FUNKY MAGIC - to see if this is a file REALLY being locked!!!
                if (IsFileLocked(ex)) {
                    // do something, eg File.Copy or present the user with a MsgBox - I dont recommend Killing the process thats locking it
                    return false;
                }
            }
            finally {
            }
            return true;
        }
    
        const int ERROR_SHARING_VIOLATION = 32;
        const int ERROR_LOCK_VIOLATION = 33;    
        private static bool IsFileLocked(Exception exception)
        {
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
        }
    }
