    private void btnSelectImage_Click(object sender, RoutedEventArgs e)
    {
        // Configure open file dialog box 
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.Filter = "";
    
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        string sep = string.Empty;
    
        foreach (var c in codecs)
        {
           string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
           dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
           sep = "|";
        }
    
        dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*"); 
             
        dlg.DefaultExt = ".png"; // Default file extension 
     
        // Show open file dialog box 
        Nullable<bool> result = dlg.ShowDialog();
    
        // Process open file dialog box results 
        if (result == true)
        {
           // Open document 
           string fileName  = dlg.FileName;
           // Do something with fileName  
        }
    } 
