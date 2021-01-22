                do
                {
                    try
                    {
                        DisableReadOnly(directory);
                        directory.Delete(true);
                    }
                    catch (Exception)
                    {
                        retryDeleteDirectoryCount++;
                    }
                } while (Directory.Exists(fullPath) && retryDeleteDirectoryCount < 4);
