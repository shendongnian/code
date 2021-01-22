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
                // Code to be run after file copy is done
            }
        }
