    public void DeleteFileFromFolder(string StrFilename)
    {
    
    	string strPhysicalFolder = Server.MapPath("..\\");
    
    	string strFileFullPath = strPhysicalFolder + StrFilename;
    
    	if (IO.File.Exists(strFileFullPath)) {
    		IO.File.Delete(strFileFullPath);
    	}
    
    }
