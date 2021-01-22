    using System.IO;
    using System.IO.MemoryMappedFiles;
    
    class Test
    {
        static void Main()
        {
            FileStream file = File.OpenRead("Test.cs");
            using (MemoryMappedFile mappedFile = MemoryMappedFile.CreateFromFile
                   (file, "PEIMAGE", file.Length, MemoryMappedFileAccess.Read, null, 0, false))
            {
                using (var viewStream = mappedFile.CreateViewStream
                       (0, file.Length, MemoryMappedFileAccess.Read))
                {
                    // read from the view stream
                }
            }
        }
    }
