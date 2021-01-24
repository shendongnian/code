    using System;
    using System.IO;
    using System.Linq;
    namespace ConsoleApp1
    {
        class Program
        {
            private static string _monitoringPath = @"C:\temp";
            private static string _destinationPath = @"C:\dest";
            static void Main(string[] args)
            {
                MonitorDirectory(_monitoringPath);
                Console.ReadKey();
            }
            public static void MonitorDirectory(string path)
            {
                var watcher = new FileSystemWatcher();
                watcher.Path = path;
                watcher.NotifyFilter = NotifyFilters.LastWrite;
                watcher.Changed += FileCreatedInMonitoredDirectory;
                watcher.EnableRaisingEvents = true;
            }
            private static void FileCreatedInMonitoredDirectory(object sender, FileSystemEventArgs e)
            {         
                MoveFilesInDirectory(_monitoringPath);
                System.Threading.Thread.Sleep(1000);
            }
            private static bool CanFileBeOpened(string path)
            {
                try
                {
                    using (var file = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                        return true;
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine($"Warning: File could not be opened, it will not be moved. {ioEx}" );
                    return false;
                }
            }
            private static void MoveFilesInDirectory(string dirPath)
            {
                string[] fileNames = Directory.GetFiles(dirPath);
                var sortedFileNames = from fn in fileNames
                                      orderby new FileInfo(fn).Name ascending
                                      orderby new FileInfo(fn).LastWriteTime ascending
                                      select new FileInfo(fn).Name;
                foreach (string fileName in sortedFileNames)
                {
                    string filePath = Path.Combine(_monitoringPath, fileName);
                    if (!CanFileBeOpened(filePath))
                        continue;
                    var fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length > 0)
                    {
                        File.Move(Path.Combine(_monitoringPath, fileName), Path.Combine(_destinationPath, fileName));
                        Console.WriteLine($"File {fileName} has been moved successfully.");
                    }
                }
            }
        }
    }
