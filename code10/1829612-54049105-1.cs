    public void main()
    {
    // Get the file path from the SSIS variable
    string FilePath = Dts.Variables["User::Filename"].Value.ToString();
    // Use the FileInfo method from System.IO to get the file object
    FileInfo file = new FileInfo(FilePath);
    // Save file properties back to SSIS variables
    Dts.Variables["User::FileCreatedDateTime"].Value = file.CreationTime;
    Dts.Variables["User::FileSize"].Value = file.Length;
    // Return success
    Dts.TaskResult = (int)ScriptResults.Success;
    }
