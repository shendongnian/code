    using Ionic.Zip; 
    bool wasCanceled = false;
    ZipFile zip;
    
    using (zip = new ZipFile())
    {
        zip.SaveProgress += zipProgress;    
        zip.AddDirectory(@"C:\SomeFolder");                                
        zip.Save(@"C:\SomeFolder.zip");
    }
    private void zipProgress(object sender, SaveProgressEventArgs e)
    {
        if(wasCanceled) { e.Cancel = true; }
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
        wasCanceled = true;
    }
