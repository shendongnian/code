    public void WriteToHiddenFile(string fname)
    {
        TextWriter    outf;
        FileInfo      info;  
  
        info = new FileInfo(fname);
        info.Attributes = FileAttributes.Normal;    // Set file to unhidden
        outf = new StreamWriter(fname);             // Open file for writing
        info.Attributes = FileAttributes.Hidden;    // Set back to hidden
        outf.WriteLine("test output.");             // Write to file
        outf.Close();                               // Close file
    }
