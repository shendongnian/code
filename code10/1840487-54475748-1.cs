    string data = new System.Net.WebClient() { Proxy = null }.DownloadString("https://pastebin.com/raw/ai8q5GEA");
    // Split on line breaks
    var lines = data.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    // Search for license key (might want to change this) 
    var foundLicense = lines.FirstOrDefault(l => l.StartsWith(fin));
    if (foundLicense != null)
    {
    	var values = foundLicense.Split('|');
    	var whitelist = values[0];
    	var date = DateTime.ParseExact(values[1], "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
    	var username = values[2];
        /* ...  */
    }
