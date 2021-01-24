        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            if (sourceDirName.Contains("System Volume Information"))
                return;
            //textb_Status.AppendText("Current Directory: " + sourceDirName +"\n");
            DirectoryInfo[] dirs = null;
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (sourceDirName.Contains("$")) // avoids $Recycle Bin
                return;
            if (!dir.Exists)
            {
                textb_Status.AppendText("Issue with " + dir.FullName + " This folder will not be compied.");
                return;
                //throw new DirectoryNotFoundException(
                // "Source directory does not exist or could not be found: "
                //  + sourceDirName);
            }
            {
                dirs = dir.GetDirectories();
                // If the destination directory doesn't exist, create it.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }
                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    try
                    {
                        if (File.Exists(temppath)) // Check for newer
                        {
                            FileInfo sourcefile = new FileInfo(file.FullName);
                            FileInfo destFile = new FileInfo(temppath);
                            int CompareValue = sourcefile.LastWriteTime.CompareTo(destFile.LastWriteTime); //<0==> Earlier (old)  =0 ==> same  >0 Later (newer)
                                                                                                           //textb_Status.AppendText("CompareValue: " + CompareValue + "\n");
                            if (CompareValue > 0) // Represents newer file
                            {
                                file.CopyTo(temppath, true);
                                textb_Status.AppendText("********** Updated: " + file.FullName + "********* \n");
                            }
                        }
                        else
                        {
                            file.CopyTo(temppath);
                        }
                    }
                    catch (PathTooLongException)
                    {
                        textb_Status.AppendText("Filename Too long \r\n\n " + file.FullName + "\r\n\n");
                    }
                    catch (IOException ex)
                    {
                        FileInfo sourcefile = new FileInfo(file.FullName);
                        FileInfo destFile = new FileInfo(temppath);
                        int CompareValue = sourcefile.LastWriteTime.CompareTo(destFile.LastWriteTime); //<0==> Earlier (old)  =0 ==> same  >0 Later (newer)
                                                                                                       //textb_Status.AppendText("CompareValue: " + CompareValue + "\n");
                        if (CompareValue > 0) // Represents newer file
                        {
                            file.CopyTo(temppath, true);
                            textb_Status.AppendText("Updated: " + file.FullName + "\n");
                        }
                    }
                    catch (Exception ex2)
                    {
                        textb_Status.AppendText("Issue with " + file.FullName + "\n");
                        textb_Status.AppendText("Error Message \n");
                        textb_Status.AppendText(ex2.Message + "\n\n");
                    }
                }
                // If copying subdirectories, copy them and their contents to new location.
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
        }
