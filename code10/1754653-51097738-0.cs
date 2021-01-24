                   sftp.Connect();
                    var files = sftp.ListDirectory(pathRemoteDirectory);
                    // Iterate over them
                    foreach (SftpFile file in files)
                    {
                        if (!file.IsDirectory && !file.IsSymbolicLink)
                        {
                            using (Stream fileStream = File.OpenWrite(Path.Combine(pathLocalDirectory, file.Name)))
                            {
                                sftp.DownloadFile(file.FullName, fileStream);
                                Debug.WriteLine(pathLocalDirectory);
                            }
                        }
                        else if (file.Name != "." && file.Name != "..")
                        {
                            Debug.WriteLine("Directory Ignored {0}", file.FullName);
                        }
                        else if (file.IsSymbolicLink)
                        {
                            Debug.WriteLine("Symbolic link ignored: {0}", file.FullName);
                        }
                    }
                    sftp.Disconnect();
