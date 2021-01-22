    System.Threading.ThreadPool.QueueUserWorkItem(s =>
            {
                while (true)    // might want a real condition like while(!backupNotDone)
                {
                    int SizeofBackup = (int) (((BackupSize.BackupSize)/1024f)/1024f)/1024;
                    Console.WriteLine("Backup Size: " + Convert.ToString(SizeofBackup + "G"));
                }
            });
