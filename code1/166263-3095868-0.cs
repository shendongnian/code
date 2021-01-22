    using System;
    using System.IO;
    using Microsoft.SqlServer.Management.Smo;
    
    namespace BackupDatabases
    {
        class Program
        {
            static void Main()
            {
    
                const string path = @"C:\Backups\";
    
                 if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
    
                Console.WriteLine("Enter Server name");
                string server = Console.ReadLine();
    
                Server sqlServer = new Server(server);
    
                
                foreach (Database db in sqlServer.Databases)
                {
    
                    Backup bk = new Backup();
    
                    bk.Devices.AddDevice(path, DeviceType.File);
                    bk.Action = BackupActionType.Database;
                    bk.BackupSetDescription = "Full backup of " + db.Name;
                    bk.Database = db.Name;
                    bk.Initialize = true;
    
                    Console.WriteLine("Backing up database " + db.Name);
    
                    bk.SqlBackup(sqlServer);
    
                    Console.WriteLine();
                    Console.WriteLine("Backup complete for database " + db.Name);
    
                }
    
            }
    
        }
    }
