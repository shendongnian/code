    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace QXBackup
    {
        class main
        {
            static void Main(string[] args)
            {
                var bgWorker = new BackgroundWorker();
                bgWorker.WorkerReportsProgress = true;
    
                bgWorker.DoWork += (sender, e) =>
                {
                    lacie BackupDrive = new lacie();
                    BackupDrive.findLacie();
    
                    xml xmlFile = new xml();
                    xmlFile.ProcessXML();
    
                    size BackupSize = new size();
                    BackupSize.GetSize(xmlFile.Path);
    
                    int SizeofBackup = (int)(((BackupSize.BackupSize) / 1024f) / 1024f) / 1024;
                    Console.WriteLine("Drive Letter: " + BackupDrive.Drive);
                    Console.WriteLine("Volume Name: " + BackupDrive.VolumeLabel);
                    Console.WriteLine("Free Space: " + Convert.ToString(BackupDrive.AvailableSize) + "G");
                    Console.WriteLine("Size of Lacie: " + Convert.ToString(BackupDrive.TotalSize) + "G");
                    Console.WriteLine("Backup Size: " + Convert.ToString(SizeofBackup + "G"));
                    Console.WriteLine("Backing up " + BackupSize.FileCount + " files found in " + BackupSize.FolderCount + " folders.");
                    Console.ReadKey(true);
                };
    
                bgWorker.RunWorkerCompleted += (sender, e) => Console.WriteLine("completed...");
                bgWorker.ProgressChanged += (sender, e) => Console.WriteLine("progressing...");
    
    
                bgWorker.RunWorkerAsync();
            }
        }
    }
