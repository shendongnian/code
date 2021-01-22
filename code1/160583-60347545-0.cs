    public static class FileInfoExtension
    {
        //second parameter is need to avoid collision with native MoveTo
        public static void MoveTo(this FileInfo file, string destination, bool autoCreateDirectory) { 
        
            if (autoCreateDirectory)
            {
                var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(destination));
                if (!destinationDirectory.Exists)
                    destinationDirectory.Create();
            }
            file.MoveTo(destination);
        }
    }
