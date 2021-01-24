    public void Main()
    {
        string strdirectory = @"C:\Users\AShubhankar\Desktop\archive_feb";
        //if the director exists then proceed
        if (Directory.Exists(strdirectory))
        {
            string[] fileList = Directory.GetFiles(strdirectory,"*.*",SearchOption.AllDirectories);
            foreach (string strfile in fileList)
            {
                string newFileName = GetNewFileName(strfile);
                //rename the new file
               File.Move(strfile, newFileName);
            }
            Dts.TaskResult = (int)ScriptResults.Success;
        }
        else
        {
            MessageBox.Show("Directory not found");
            Dts.TaskResult = (int)ScriptResults.Failure;
        }
    }
    // Function to get the new file name        
    public string GetNewFileName(string strfile)
    {
        string shortDate = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string extension = ".txt";
        return string.Concat(Path.GetDirectoryName(strfile),Path.GetFileNameWithoutExtension(strfile), "_", shortDate, extension);
    }
