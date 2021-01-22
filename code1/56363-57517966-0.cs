    string str_path_and_name = str_path + '\\' + str_filename;
    FileInfo fInfo = new FileInfo(str_path_and_name);
    bool open_elsewhere = false;
    try
    {
        fInfo.MoveTo(str_path_and_name);
    }
    catch (Exception ex)
    {
        open_elsewhere = true;
        MessageBox.Show("The selected file cannot be uploaded while open in another program.  Please close the file and try again.", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
