            public static string Source = @"\\192.168.1.11\Z$\z";
    
            public static string Destination = @"\\192.168.1.11\Z$\z_rar\";
    
            public static string NameFormat = DateTime.Now.ToString("dddd");
    
            public static string Extension = @".zip";
    
            public static string LogFilePath = Destination + NameFormat + "_log.txt";
    
    
            private static void Main(string[] args)
            {
                File.Delete(Destination + NameFormat + Extension);
                File.Delete(LogFilePath);
    
                try
                {
                    ZipFile.CreateFromDirectory(Source, Destination + NameFormat + Extension,
                        CompressionLevel.NoCompression, false);
    
                    var fileListBuilder = new StringBuilder();
    
                    using (var za = ZipFile.OpenRead(Destination + NameFormat + Extension))
                    {
                        foreach (var zae in za.Entries) fileListBuilder.AppendLine(zae.FullName);
                    }
    
    
                    File.WriteAllText(LogFilePath, fileListBuilder.ToString());
                }
                catch (IOException e)
                {
                    File.WriteAllText(LogFilePath, e.ToString());
                }
            }
