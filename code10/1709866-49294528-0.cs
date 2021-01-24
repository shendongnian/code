                try
                {
                    if (ext == ".rar")
                    {
                        System.IO.Directory.CreateDirectory(@"" + ppath);
                        try
                        {
                            NUnrar.Archive.RarArchive.WriteToDirectory(filename, ppath, NUnrar.Common.ExtractOptions.ExtractFullPath | NUnrar.Common.ExtractOptions.Overwrite);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                           
                        }
                    }
                    else if (ext == ".zip")
                    {
                        System.IO.Directory.CreateDirectory(@"" + ppath);
                        try
                        {
                            ZipFile.ExtractToDirectory(filename, ppath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
