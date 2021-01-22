    void w_Changed(object sender, FileSystemEventArgs e) 
    { 
        // IOException on following line 
        using (ZipInputStream s = new ZipInputStream(new System.IO.FileStream(e.FullPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))) 
        { 
            ... 
        } 
        // delete the zip file 
        File.Delete(e.FullPath); 
    } 
