    namespace System.IO
    {
        public static class ExtendedMethod
        {
            public static void Rename(this FileInfo fileInfo, string newName)
            {
                if (fileInfo.Directory != null)
                    System.IO.File.Move(fileInfo.FullName, fileInfo.Directory.FullName + "\\" + newName);
        
            }
        }
    }
