    using System.IO;
    static long GetFileSize(string FilePath)
    {
        //if you don't have permission to the folder, Directory.Exists will return False
        if(!Directory.Exists(Path.GetDirectoryName(FilePath))
        {
            //if you land here, it means you don't have permission to the folder
            Debug.Write("Permission denied");
            return -1;
        }
        else if(File.Exists(FilePath))
        {
            return new FileInfo(FilePath).Length;
        }
        return 0;
    }
