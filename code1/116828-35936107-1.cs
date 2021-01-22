    private void ProcessFile(string path)
    {
    	string connString = string.Empty;
    
    	if (Path.GetExtension(path).ToLower().Trim() == ".xls" && Environment.Is64BitOperatingSystem == false)
    		connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
    	else
    		connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
    }
