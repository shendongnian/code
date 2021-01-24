                    StorageFile f = await folder.CreateFileAsync("test.zip");
                    using (Stream s = (await f.OpenStreamForWriteAsync()))
                    {
                        using (ZipArchive zz = new ZipArchive(s, ZipArchiveMode.Update))
                        {
                            ZipArchiveEntry read = zz.CreateEntry("scc.txt");
                            using (StreamWriter sw = new StreamWriter(read.Open()))
                            {
                                await sw.WriteLineAsync("StackOverFlow");
                                await sw.WriteLineAsync("Thanks!");
                            }
                        }
                    }
