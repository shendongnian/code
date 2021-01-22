    WebClient wc = new WebClient();
    wc.UploadData(
        "http://imgur.com/api/upload.xml", "POST", 
        Encoding.UTF8.GetBytes(
            String.Join("&", 
                new Dictionary<string, string>()
                {
                    { "key", "YOUR_API_KEY" },
                    { "image", Convert.ToBase64String(File.ReadAllBytes("file.png"))}
                }.Select(item => 
                    String.Format("{0}={1}", 
                        item.Key, HttpUtility.UrlEncode(item.Value)))
                .ToArray())));
        
