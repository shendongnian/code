    private void processing(string directory)
            {
                cmbFilesTypesSelectedIndex = cmbFilesTypes.SelectedIndex;
                CheckForProjectFile(directory);
                DirectoryInfo dInfo = new DirectoryInfo(directory);
                DirectoryInfo[] dirs = dInfo.GetDirectories() ;
                foreach (DirectoryInfo subDir in dirs)
                {
                    CheckForProjectFile(subDir.FullName);
                    processing(subDir.FullName);
                }
            }
    
            private void CheckForProjectFile(string directory)
            {
                Boolean flag = false; 
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                FileInfo[] files = dirInfo.GetFiles();
                //You can also traverse in files also
                foreach (FileInfo subfile in files)
                {
                    //Do you want
                   
                }
            }
