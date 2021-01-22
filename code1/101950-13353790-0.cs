    //ALLYOURNAMESPACESHERE
    using ...
    //SHARPLIB
    using ICSharpCode.SharpZipLib.Zip;
    using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
    public static class FileUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public static void ZipFile(string sourcePath, string targetPath)
        {
            string tempZipFilePath = targetPath;
            using (FileStream tempFileStream = File.Create(tempZipFilePath, 1024))
            {
                using (ZipOutputStream zipOutput = new ZipOutputStream(tempFileStream))
                {
                    // Zip with highest compression.
                    zipOutput.SetLevel(9);
                    DirectoryInfo directory = new DirectoryInfo(sourcePath);
                    foreach (System.IO.FileInfo file in directory.GetFiles())
                    {
                        // Get local path and create stream to it.
                        String localFilename = file.FullName;
                        //ignore directories or folders
                        //ignore Thumbs.db file since this probably will throw an exception
                        //another process could be using it. e.g: Explorer.exe windows process
                        if (!file.Name.Contains("Thumbs") && !Directory.Exists(localFilename))
                        {
                            using (FileStream fileStream = new FileStream(localFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                // Read full stream to in-memory buffer.
                                byte[] buffer = new byte[fileStream.Length];
                                fileStream.Read(buffer, 0, buffer.Length);
                                // Create a new entry for the current file.
                                ZipEntry entry = new ZipEntry(file.Name);
                                entry.DateTime = DateTime.Now;
                                // set Size and the crc, because the information
                                // about the size and crc should be stored in the header
                                // if it is not set it is automatically written in the footer.
                                // (in this case size == crc == -1 in the header)
                                // Some ZIP programs have problems with zip files that don't store
                                // the size and crc in the header.
                                entry.Size = fileStream.Length;
                                fileStream.Close();
                                // Update entry and write to zip stream.
                                zipOutput.PutNextEntry(entry);
                                zipOutput.Write(buffer, 0, buffer.Length);
                                // Get rid of the buffer, because this
                                // is a huge impact on the memory usage.
                                buffer = null;
                            }
                        }
                    }
                    // Finalize the zip output.
                    zipOutput.Finish();
                    // Flushes the create and close.
                    zipOutput.Flush();
                    zipOutput.Close();
                }
            }
        }
        public static void unZipFile(string sourcePath, string targetPath)
        {
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(sourcePath)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    if (theEntry.Name != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(targetPath + "\\" + theEntry.Name))
                        {
                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
