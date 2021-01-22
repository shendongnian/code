    private Process openApplication;  
    private void btnOpenFile_Click(object sender, EventArgs e) {  
        ...
        // copy current file to fileCache  
        ...  
        // open fileCache with proper application
        openApplication = System.Diagnostics.Process.Start( fileCache );  
    }
