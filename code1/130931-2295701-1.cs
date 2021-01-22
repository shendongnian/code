    public static void DeleteFilesInFolder()
            {
                using(var dlg = new FolderBrowserDialog())
                {
                    if(dlg.ShowDialog() == DialogResult.OK)
                    {
                        var folderPath = dlg.SelectedPath;
                        var dir = new DirectoryInfo(folderPath);
                        var files =dir.GetFiles();
                        foreach (var f in files)
	                {
                        try
                        {
                            f.Delete();
                        }
                        catch (Exception ex) {
                            //handle this error
                        }
	                }
                    }
                }
            }
