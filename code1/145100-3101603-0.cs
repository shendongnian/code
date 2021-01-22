            public static string[] GetFiles()
        {
            string[] fileNames;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = UniversalDataImporter.Properties.Settings.Default.openFilePath;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = false;
            openFileDialog1.Multiselect = true;
            openFileDialog1.CheckFileExists = false;
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK && openFileDialog1.FileNames.Count() <501 )
                {
                    UniversalDataImporter.Properties.Settings.Default.openFilePath =
                        Path.GetDirectoryName(openFileDialog1.FileName);
                    UniversalDataImporter.Properties.Settings.Default.Save();
                    return fileNames = openFileDialog1.FileNames;
                }
                else if (result == DialogResult.Cancel)
                {
                    return null;
                }
                else
                {
                    if (MessageBox.Show("Too many files were Selected. Would you like to import a folder instead?",
                        "Too many files...", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        return fileNames = GetFilesInFolder();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                return null;
            }
        }
        public static string[] GetFilesInFolder()
        {
            
            FileInfo[] fileInfo;
            
            string pathName;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.Desktop;
            DialogResult results = folderBrowserDialog.ShowDialog();
            if (results == DialogResult.OK)
            {
                try
                {
                    pathName = folderBrowserDialog.SelectedPath;
                    DirectoryInfo dir = new DirectoryInfo(pathName);
                    if (dir.Exists)
                    {
                        fileInfo = dir.GetFiles();
                        string[] fileNames = new string[fileInfo.Length];
                        for (int i = 0; i < fileInfo.Length; i++)//this is shit
                        {
                            fileNames[i] = fileInfo[i].FullName;
                        }
                        return fileNames;
                    }
                    else
                    {
                        return null;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    return null;
                }
            }
            else if (results == DialogResult.Cancel) 
            {
                return null;
            }
            else { return null; }
        }
