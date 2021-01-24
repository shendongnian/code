    void Main()
    {
    	string fin = "111";
    
    	string data = new System.Net.WebClient() { Proxy = null }.DownloadString("https://pastebin.com/raw/ai8q5GEA");
    
    	// Parse data to DTO-objects
    	var licenseData = data.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
    		.Select(l => l.Split('|'))
    		.Select(x => new LicenseModel
    		{
    			LicenseKey = x[0],
    			Date = DateTime.ParseExact(x[1], "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
    			Username = x[2]
    		})
    		.ToList();
    
    	// Find matching license
    	var foundLicense = licenseData.FirstOrDefault(l => l.LicenseKey.StartsWith(fin));
    	if (foundLicense != null)
    	{
            /* FOUND LICENSE  */
    	}
    }
    
    
    public class LicenseModel
    {
    	public string LicenseKey { get; set; }
    	public DateTime Date { get; set; }
    	public string Username { get; set; }
    }
