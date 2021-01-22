    if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
    {
        using (System.Net.WebClient client = new System.Net.WebClient())
        {                        
              client.DownloadFileAsync(new Uri("http://www.examplesite.com/test.txt"),
              "D:\\test.txt");
        }                  
    }
