    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://example.com/remote/path/");
    request.Method = WebRequestMethods.Ftp.ListDirectory;
    request.Credentials = new NetworkCredential("username", "password");
    comboBox1.BeginUpdate();
    try
    {
        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                comboBox1.Items.Add(reader.ReadLine());
            }
        }
    }
    finally
    {
        comboBox1.EndUpdate();
    }
