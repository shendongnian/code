    using System;
    using System.IO.Compression;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace ZipAndUnzip
    {
        class Program
        {
            static void Main(string[] args)
            {
                var directoryPath = new DirectoryInfo(@"C:\your_path\");
    
                Compress(directoryPath);
                Decompress(directoryPath);
            }
    
            public static void Compress(DirectoryInfo directoryPath)
            {
                foreach (DirectoryInfo directory in directoryPath.GetDirectories())
                {
                    var path = directoryPath.FullName;
                    var newArchiveName = Regex.Replace(directory.Name, "[0-9]{8}", "20130913");
                    newArchiveName = Regex.Replace(newArchiveName, "[_]+", "_");
                    string startPath = path + directory.Name;
                    string zipPath = path + "" + newArchiveName + ".zip";
    
                    ZipFile.CreateFromDirectory(startPath, zipPath);
                }
    
            }
    
            public static void Decompress(DirectoryInfo directoryPath)
            {
                foreach (FileInfo file in directoryPath.GetFiles())
                {
                    var path = directoryPath.FullName;
                    string zipPath = path + file.Name;
                    string extractPath = Regex.Replace(path + file.Name, ".zip", "");
    
                    ZipFile.ExtractToDirectory(zipPath, extractPath);
                }
            }
    
    
        }
    }
