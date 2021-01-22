    string url = YOUR_TEXTBOX.Text();
    Uri uri;
    
    try {
     uri = new Uri(url);
    }
    catch (UriFormatException ex) {
     // Error
     throw ex;
    }
    
    byte[] file;
    
    using (System.Net.WebClient client = new System.Net.WebClient()) {
     file = client.DownloadData(uri);
    }
    // now you have the file
