    public class AsyncFileCopier
        {
            public delegate void FileCopyDelegate(string sourceFile, string destFile);
    
            public static void AsynFileCopy(string sourceFile, string destFile)
            {
                FileCopyDelegate del = new FileCopyDelegate(FileCopy);
                IAsyncResult result = del.BeginInvoke(sourceFile, destFile, CallBackAfterFileCopied, null);
            }
    
            public static void FileCopy(string sourceFile, string destFile)
            { 
                // Code to copy the file
            }
    
            public static void CallBackAfterFileCopied(IAsyncResult result)
            {
                // Notify UI by calling an async del (probably using fire & forget approach or another callback if desired)
            }
        }
