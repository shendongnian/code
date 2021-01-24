        private static void CreateEncryptedZipFile(string filename, string to, FileInfo fi, string password)
        {
            using (var zipFile = new Ionic.Zip.ZipFile())
            {
                zipFile.Password = password;
                zipFile.Encryption = Ionic.Zip.EncryptionAlgorithm.WinZipAes256;
                zipFile.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zipFile.AddFile(filename, directoryPathInArchive: string.Empty);
                zipFile.MaxOutputSegmentSize = 1024*1024*128;
                zipFile.Save(to + ".zip");
            }
            createXMLInfo(fi, to);
        }
