    using System;
    using System.Configuration;
    using System.IO;
    using System.Threading;
    
    namespace FolderSyncing
    {
        public class FolderSync
        {
            private readonly string masterDirectoryPath;
            private readonly string slaveDirectoryPath;
    
            public FolderSync()
            {
                masterDirectoryPath = ConfigurationManager.AppSettings.Get("MasterDirectory");
                slaveDirectoryPath = ConfigurationManager.AppSettings.Get("SlaveDirectory");
                
                if (Directory.Exists(masterDirectoryPath) && Directory.Exists(slaveDirectoryPath))
                {
                    FTPFileSystemWatcher watcher = new FTPFileSystemWatcher(masterDirectoryPath);
                    watcher.FTPFileChanged += watcher_FTPFileChanged;
                    watcher.FTPFileCreated += watcher_FTPFileCreated;
                    watcher.FTPFileDeleted += watcher_FTPFileDeleted;
                }
                else
                {
                    Console.WriteLine("Directories were not located check config paths");
                }
                
            }
    
            void watcher_FTPFileDeleted(object sender, FileSystemEventArgs e)
            {
                DeleteFile(slaveDirectoryPath + e.Name, 5, 1);
            }
    
            void watcher_FTPFileCreated(object sender, FileSystemEventArgs e)
            {
                CopyFile(e.Name,5,1);
            }
    
            void watcher_FTPFileChanged(object sender, FileSystemEventArgs e)
            {
                
            }
    
            private void DeleteFile(string fullPath, int attempts, int attemptNo)
            {
                if (File.Exists(fullPath))
                {
                    try
                    {
                        File.Delete(fullPath);
                        Console.WriteLine("Deleted " + fullPath);
                    }
                    catch (Exception)
                    {
                        if (attempts > attemptNo)
                        {
                            Console.WriteLine("Failed deleting  " + fullPath + "trying again "+ attemptNo.ToString()+ " of "+attempts);
                            Thread.Sleep(500);
                            DeleteFile(fullPath, attempts, attemptNo + 1);
                        }
                        else
                        {
                            Console.WriteLine("Critically Failed deleting  " + fullPath);
                        }
                    }
                }
            }
    
            private void CopyFile(string fileName,int attempts, int attemptNo)
            {
                string masterFile = masterDirectoryPath + fileName;
                string slaveFile = slaveDirectoryPath + fileName;
                if (File.Exists(masterFile))
                {
                    try
                    {
                        File.Copy(masterFile,slaveFile);
                        Console.WriteLine("Copied  " + masterFile);
                    }
                    catch (Exception)
                    {
                        if (attempts > attemptNo)
                        {
                            Console.WriteLine("Failed copying  " + masterFile + "trying again " + attemptNo.ToString() + " of " + attempts);
                            Thread.Sleep(500);
                            CopyFile(fileName, attempts, attemptNo + 1);
                        }
                        else
                        {
                            Console.WriteLine("Critically Failed copying  " + masterFile);
                        }
                    }
                }
           }
        }
    }
