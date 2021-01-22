    string path = "Reasonably large file.dat";
    int bufferSize = 1024;
    byte[] buffer = new byte[bufferSize];
    System.Net.HttpWebRequest req = (HttpWebRequest)System.Net.HttpWebRequest.Create("Some URL");
    req.Method = "PUT";
    req.Timeout = 3000; //3 seconds, small timeout to demonstrate
    long length = new System.IO.FileInfo(path).Length;
    using (FileStream input = File.OpenRead(path))
    {
        using (Stream output = req.GetRequestStream())
        {
            long remaining = length;
            int bytesRead = 0;
            while ((bytesRead = input.Read(buffer, 0, (int)Math.Min(remaining, (decimal)bufferSize))) > 0)
            {
                output.Write(buffer, 0, bytesRead);
                remaining -= bytesRead;
            }
            output.Close();
        }
    input.Close();
    }
