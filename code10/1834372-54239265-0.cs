    using System.Globalization;
                string folderPath = @"C:\YourFolder\";
                Server serv = new Server(@"YourServer");
                Backup bkup = new Backup();
                bkup.Database = "YourDatabase";
                string bkupFilePath = folderPath + bkup.Database.ToString() + ".bak";
                bkup.Action = BackupActionType.Database;
                bkup.Devices.AddDevice(bkupFilePath, DeviceType.File);
                bkup.BackupSetName = "YourDatabase Full Backup";
                bkup.BackupSetDescription = "Full backup of YourDatabase";
                DateTime today = DateTime.Now;
                //define current date representation with en-US culture
                string newLocale = today.ToString(new CultureInfo("en-US"));
                //set Backup.ExpirationDate to use new culture
                bkup.ExpirationDate = Convert.ToDateTime(newLocale);
                bkup.ExpirationDate.AddDays(10);
                bkup.ExpirationDate.AddDays(100);
                bkup.ExpirationDate.AddDays(500);
                bkup.ExpirationDate.AddDays(1000);
                bkup.SqlBackup(serv);
