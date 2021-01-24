    var all_subdirectories = System.IO.Directory.GetDirectories(folderPath);
    
    foreach (var tmp_variables in all_subdirectories)
    {
        // Get the directory name only from filepath
        MessageBox.Show(System.IO.Path.GetFileName(tmp_variables));
    }
