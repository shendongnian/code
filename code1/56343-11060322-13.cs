    using System.IO;
    using System.Runtime.InteropServices;
    internal static class Helper
    {
    const int ERROR_SHARING_VIOLATION = 32;
    const int ERROR_LOCK_VIOLATION = 33;
    
    private static bool IsFileLocked(Exception exception)
    {
        int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
        return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
    }
    
    internal static bool CanReadFile(string filePath)
    {
        //Try-Catch so we dont crash the program and can check the exception
        try {
            //The "using" is important because FileStream implements IDisposable and
            //"using" will avoid a heap exhaustion situation when too many handles  
            //are left undisposed.
            using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
                if (fileStream != null) fileStream.Close();  //This line is me being overly cautious, fileStream will never be null unless an exception occurs... and I know the "using" does it but its helpful to be explicit - especially when we encounter errors - at least for me anyway!
            }
        }
        catch (IOException ex) {
            //THE FUNKY MAGIC - TO SEE IF THIS FILE REALLY IS LOCKED!!!
            if (IsFileLocked(ex)) {
                // do something, eg File.Copy or present the user with a MsgBox - I do not recommend Killing the process that is locking the file
                return false;
            }
        }
        finally
        { }
        return true;
    }
    }
