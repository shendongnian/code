    thread = new Thread(
                new ThreadStart(() =>
                {
                    using (Archive = RarArchive.Open(streams, new ReaderOptions() { Password = password, LookForHeader = true }))
                    {
                        Archive.EntryExtractionBegin += EntryExtractionBeginEvet;
                        Archive.CompressedBytesRead += CompressedBytesReadEvent;
                        FilesTotalCount = Archive.Entries.Count();
                        TotalSize = Archive.TotalSize;
                        foreach (IArchiveEntry ArchiveEntry in Archive.Entries.Where(entry => !entry.IsDirectory))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(@"" + path + "\\" + ArchiveEntry.Key));
                            using (Stream archiveStream = ArchiveEntry.OpenEntryStream())
                            using (FileStream fileStream = new FileStream(@"" + path + "\\" + ArchiveEntry.Key, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                            {
                                int byteSizes = 0;
                                byte[] buffer = new byte[bufferLenght];
                                while (ThreadState == ThreadState.Running && (byteSizes = archiveStream.Read(buffer, 0, buffer.Length)) > 0)
                                    fileStream.Write(buffer, 0, byteSizes);
                            }
                        }
                    }
                    IO.CloseStreams(streams);
                }
            ));
            thread.Start();
