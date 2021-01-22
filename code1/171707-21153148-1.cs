    namespace System.IO
    {
        public static class ExtendedMethod
        {
            public static void Rename(this FileInfo fileInfo, string newName)
            {
               fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName);
            }
        }
    }
