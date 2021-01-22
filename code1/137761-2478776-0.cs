    System.Net.WebClient client = new System.Net.WebClient();
    string url = @"http://www.daikodo.com/genki-back/back-img/10genki-2.jpg";
    string savePath = @"C:\Temp\test.jpg";
    
    Console.WriteLine("Downloading from: " + url);
    byte[] result = client.DownloadData(url);
    System.IO.File.WriteAllBytes(savePath, result);
    
    Console.WriteLine("Download is done! It has been saved to: " + savePath);
    Console.ReadKey();
