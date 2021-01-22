    var mimeTypeListUrl = "http://svn.apache.org/repos/asf/httpd/httpd/trunk/docs/conf/mime.types";
    var webClient = new WebClient();
    var rawData = webClient.DownloadString(mimeTypeListUrl).Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
    
    var extensionToMimeType = new Dictionary<string, string>();
    var mimeTypeToExtension = new Dictionary<string, string[]>();
    
    foreach (var row in rawData)
    {
        if (row.StartsWith("#")) continue;
    
        var rowData = row.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
        if (rowData.Length != 2) continue;
    
        var extensions = rowData[1].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        if (!mimeTypeToExtension.ContainsKey(rowData[0]))
        {
            mimeTypeToExtension.Add(rowData[0], extensions);
        }
    
        foreach (var extension in extensions)
        {
            if (!extensionToMimeType.ContainsKey(extension))
            {
                extensionToMimeType.Add(extension, rowData[0]);
            }
        }
    
    }
