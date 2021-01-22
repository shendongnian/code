              public void Main()
              {
                     // TODO: Add your code here
            // Author: Allan F 10th May 2019
            //first part of process .. put any files of last Qtr (or older) in Archive area 
            //e.g. if today is 10May2019 then last quarter is 1Jan2019 to 31March2019 .. any files earlier than 31March2019 will be archived
            //string SourceFileFolder = "\\\\adlsaasf11\\users$\\aford05\\Downloads\\stage\\";
            string SourceFilesFolder = (string)Dts.Variables["SourceFilesFolder"].Value;
            string ArchiveFolder = (string)Dts.Variables["ArchiveFolder"].Value;
            string FilePattern = (string)Dts.Variables["FilePattern"].Value;
            string[] files = Directory.GetFiles(SourceFilesFolder, FilePattern);
            //DateTime date = new DateTime(2019, 2, 15);//commented out line .. just for testing the dates .. 
            DateTime date = DateTime.Now;
            int quarterNumber = (date.Month - 1) / 3 + 1;
            DateTime firstDayOfQuarter = new DateTime(date.Year, (quarterNumber - 1) * 3 + 1, 1);
            DateTime lastDayOfQuarter = firstDayOfQuarter.AddMonths(3).AddDays(-1);
            DateTime LastDayOfPriorQuarter = firstDayOfQuarter.AddDays(-1);
            int PrevQuarterNumber = (LastDayOfPriorQuarter.Month - 1) / 3 + 1;
            DateTime firstDayOfLastQuarter = new DateTime(LastDayOfPriorQuarter.Year, (PrevQuarterNumber - 1) * 3 + 1, 1);
            DateTime lastDayOfLastQuarter = firstDayOfLastQuarter.AddMonths(3).AddDays(-1);
            //MessageBox.Show("debug pt2: firstDayOfQuarter" + firstDayOfQuarter.ToString("dd/MM/yyyy"));
            //MessageBox.Show("debug pt2: firstDayOfLastQuarter" + firstDayOfLastQuarter.ToString("dd/MM/yyyy"));
            
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                //MessageBox.Show("debug pt2:" + fi.Name + " " + fi.CreationTime.ToString("dd/MM/yyyy HH:mm") + " " + fi.LastAccessTime.ToString("dd/MM/yyyy HH:mm") + " " + fi.LastWriteTime.ToString("dd/MM/yyyy HH:mm"));
                if (fi.LastWriteTime < firstDayOfQuarter)
                {
                    
                    try
                    {
                      
                        FileInfo fi2 = new FileInfo(ArchiveFolder);
                        //Ensure that the target does not exist.
                        //fi2.Delete();
                        //Copy the file.
                        fi.CopyTo(ArchiveFolder + fi.Name);
                        //Console.WriteLine("{0} was copied to {1}.", path, ArchiveFolder);
                        //Delete the old location file.
                        fi.Delete();
                        //Console.WriteLine("{0} was successfully deleted.", ArchiveFolder);
                    }
                    catch (Exception e)
                    {
                        //do nothing
                        //Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                }
            }
            //second part of process .. delete any files in Archive area dated earlier than last qtr ..
            //e.g. if today is 10May2019 then last quarter is 1Jan2019 to 31March2019 .. any files earlier than 1Jan2019 will be deleted
                 
            string[] archivefiles = Directory.GetFiles(ArchiveFolder, FilePattern);
            foreach (string archivefile in archivefiles)
            {
                FileInfo fi = new FileInfo(archivefile);
                if (fi.LastWriteTime < firstDayOfLastQuarter )
                {
                    try
                    {
                        fi.Delete();
                    }
                    catch (Exception e)
                    {
                        //do nothing
                    }
                }
            }
            
                     Dts.TaskResult = (int)ScriptResults.Success;
              }
