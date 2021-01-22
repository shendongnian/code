    private string UnZipFile(string file, string dirToUnzipTo)
        {
            string unzippedfile = "";
            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(file)))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = dirToUnzipTo;
                        string fileName = Path.GetFileName(theEntry.Name);
                        string fileWDir = directoryName + fileName;
                        unzippedfile = fileWDir;
                        if (fileName != String.Empty)
                        {
                            using (FileStream streamWriter = File.Create(fileWDir))
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
            catch (Exception ex)
            {
                LogStatus.WriteErrorLog(ex, "ERROR", "DOViewer.UnZipFile");
            }
            return (unzippedfile);
        }
