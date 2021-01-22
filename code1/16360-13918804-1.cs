     ...   
    openApplication.Refresh(); 
     
    // close application if it is still open       
    if ( !openApplication.HasExited() ) {
        openApplication.Kill();  
    }
    
    // delete temporary file  
    System.IO.File.Delete( fileCache );
    
