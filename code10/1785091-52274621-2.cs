     public static void Main()
        {
            var result = IncCounter(@"D:\1.txt", FileType.TypeA);
    
            Console.WriteLine($"TypeA : {result.FileTypeACounter} - TypeB : {result.FileTypeBCounter}");
    
            Console.Read();
        }
    
        public enum FileType
        {
            TypeA,
            TypeB
        }
    
        [Serializable]
        public class FileTypeCounter
        {
            public int FileTypeACounter { get; set; }
            public int FileTypeBCounter { get; set; }
        }
    
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
    
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    
        public static FileTypeCounter IncCounter(string counterFilePath, FileType fileType)
        {
            try
            {
                var fileTypeCounter = new FileTypeCounter { FileTypeACounter = 0, FileTypeBCounter = 0 };
    
                if (!File.Exists(counterFilePath))
                {
                    if (fileType == FileType.TypeA)
                        fileTypeCounter.FileTypeACounter++;
                    else
                        fileTypeCounter.FileTypeBCounter++;
    
                    WriteToBinaryFile<FileTypeCounter>(counterFilePath, fileTypeCounter);
                    return fileTypeCounter;
                }
    
                fileTypeCounter = ReadFromBinaryFile<FileTypeCounter>(counterFilePath);
    
                switch (fileType)
                {
                    case FileType.TypeA:
                        fileTypeCounter.FileTypeACounter++;
                        break;
    
                    case FileType.TypeB:
                        fileTypeCounter.FileTypeBCounter++;
                        break;
                }
    
                WriteToBinaryFile<FileTypeCounter>(counterFilePath, fileTypeCounter);
    
                return fileTypeCounter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
