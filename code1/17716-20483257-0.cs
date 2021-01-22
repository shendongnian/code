    string randomlyGeneratedFolderNamePart = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()).Replace(".", "_");
    string timeRelatedFolderNamePart = DateTime.Now.Year.ToString()
    		                         + DateTime.Now.Month.ToString()
    		                         + DateTime.Now.Day.ToString()
    		                         + DateTime.Now.Hour.ToString()
    		                         + DateTime.Now.Minute.ToString()
    		                         + DateTime.Now.Second.ToString()
    		                         + DateTime.Now.Millisecond.ToString();
    string processRelatedFolderNamePart = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();
    
    string temporaryDirectoryName = Path.Combine( Path.GetTempPath()
    											, timeRelatedFolderNamePart 
    											+ processRelatedFolderNamePart 
    											+ randomlyGeneratedFolderNamePart);
