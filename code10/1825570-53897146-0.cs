    static void ReadFilesInArchive(string archiveFilename)
    {
        SevenZipBase.SetLibraryPath(@".\x86\7z.dll");
        var extractor = new SevenZipExtractor(archiveFilename);
    
        var filesInArchive = extractor.ArchiveFileData.ToList();
    
        filesInArchive.ForEach(f =>
        {
            using (MemoryStream ms = new MemoryStream())
            {
                extractor.ExtractFile(f.FileName, ms);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(ms))
                {
                    var lines = sr.ReadAllLines();
                    Console.WriteLine(lines.Count());
                }
            }
        });
    }
