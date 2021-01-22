                FileInfo fi = ?
                using (FileStream inFile = fi.OpenRead())
                {
                    // Get original file extension, for example "doc" from report.doc.gz.
                    string curFile = fi.FullName;
                    string origName = curFile.Remove(curFile.Length - fi.Extension.Length);
    
                    //Create the decompressed file.
                    using (FileStream outFile = File.Create(origName))
                    {
                        using (GZipStream Decompress = new GZipStream(inFile,
                                CompressionMode.Decompress))
                        {
                            //Copy the decompression stream into the output file.
                            byte[] buffer = new byte[4096];
                            int numRead;
                            while ((numRead = Decompress.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                outFile.Write(buffer, 0, numRead);
                            }
                            Console.WriteLine("Decompressed: {0}", fi.Name);
    
                        }
                    }
                }
