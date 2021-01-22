        #region CreateZipFile
        public void StartZip(string directory, string zipfile_path)
        {
            Label1.Text = "Please wait, taking backup";
                #region Taking files from root Folder
                    string[] filenames = Directory.GetFiles(directory);
                    // path which the zip file built in 
                    ZipOutputStream p = new ZipOutputStream(File.Create(zipfile_path));
                    foreach (string filename in filenames)
                    {
                        FileStream fs = File.OpenRead(filename);
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        ZipEntry entry = new ZipEntry(filename);
                        p.PutNextEntry(entry);
                        p.Write(buffer, 0 , buffer.Length);
                        fs.Close();
                    }
                #endregion
                string dirName= string.Empty;
                #region Taking folders from root folder
                    DirectoryInfo[] DI = new DirectoryInfo(directory).GetDirectories("*.*", SearchOption.AllDirectories);
                    foreach (DirectoryInfo D1 in DI)
                    {
                        // the directory you need to zip 
                        filenames = Directory.GetFiles(D1.FullName);
                        if (D1.ToString() == "backup")
                        {
                            filenames = null;
                            continue;
                        }
                        if (dirName == string.Empty)
                        {
                            if (D1.ToString() == "updates" || (D1.Parent).ToString() == "updates" || (D1.Parent).Parent.ToString() == "updates" || ((D1.Parent).Parent).Parent.ToString() == "updates" || (((D1.Parent).Parent).Parent).ToString() == "updates" || ((((D1.Parent).Parent).Parent)).ToString() == "updates")
                            {
                                dirName = D1.ToString();
                                filenames = null;
                                continue;
                            }
                        }
                        else
                        {
                            if (D1.ToString() == dirName) ;
                        }
                        foreach (string filename in filenames)
                        {
                            FileStream fs = File.OpenRead(filename);
                            byte[] buffer = new byte[fs.Length];
                            fs.Read(buffer, 0, buffer.Length);
                            ZipEntry entry = new ZipEntry(filename);
                            p.PutNextEntry(entry);
                            p.Write(buffer, 0, buffer.Length);
                            fs.Close();
                        }
                        filenames = null;
                    }
                    p.SetLevel(5);
                    p.Finish();
                    p.Close();
               #endregion
        }
        #endregion
        #region EXTRACT THE ZIP FILE
        public bool UnZipFile(string InputPathOfZipFile, string FileName)
        {
            bool ret = true;
            Label1.Text = "Please wait, extracting downloaded file";
            string zipDirectory = string.Empty;
            try
            {
                #region If Folder already exist Delete it
                if (Directory.Exists(Server.MapPath("~/updates/" + FileName))) // server data field
                {
                    String[] files = Directory.GetFiles(Server.MapPath("~/updates/" + FileName));//server data field
                    foreach (var file in files)
                        File.Delete(file);
                    Directory.Delete(Server.MapPath("~/updates/" + FileName), true);//server data field
                }
                #endregion
                if (File.Exists(InputPathOfZipFile))
                {
                    string baseDirectory = Path.GetDirectoryName(InputPathOfZipFile);
                    using (ZipInputStream ZipStream = new
                    ZipInputStream(File.OpenRead(InputPathOfZipFile)))
                    {
                        ZipEntry theEntry;
                        while ((theEntry = ZipStream.GetNextEntry()) != null)
                        {
                            if (theEntry.IsFile)
                            {
                                if (theEntry.Name != "")
                                {
                                    string directoryName = theEntry.Name.Substring(theEntry.Name.IndexOf(FileName)); // server data field
                                    string[] DirectorySplit = directoryName.Split('\\');
                                    for (int i = 0; i < DirectorySplit.Length - 1; i++)
                                    {
                                        if (zipDirectory != null || zipDirectory != "")
                                            zipDirectory = zipDirectory + @"\" + DirectorySplit[i];
                                        else
                                            zipDirectory = zipDirectory + DirectorySplit[i];
                                    }
                                    string first = Server.MapPath("~/updates") + @"\" + zipDirectory;
                                    if (!Directory.Exists(first))
                                        Directory.CreateDirectory(first);
                                    string strNewFile = @"" + baseDirectory + @"\" + directoryName;
                                    if (File.Exists(strNewFile))
                                    {
                                        continue;
                                    }
                                    zipDirectory = string.Empty;
                                    using (FileStream streamWriter = File.Create(strNewFile))
                                    {
                                        int size = 2048;
                                        byte[] data = new byte[2048];
                                        while (true)
                                        {
                                            size = ZipStream.Read(data, 0, data.Length);
                                            if (size > 0)
                                                streamWriter.Write(data, 0, size);
                                            else
                                                break;
                                        }
                                        streamWriter.Close();
                                    }
                                }
                            }
                            else if (theEntry.IsDirectory)
                            {
                                string strNewDirectory = @"" + baseDirectory + @"\" +
                                theEntry.Name;
                                if (!Directory.Exists(strNewDirectory))
                                {
                                    Directory.CreateDirectory(strNewDirectory);
                                }
                            }
                        }
                        ZipStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }  
        #endregion
