    //Removed Main code
    request.ContentType = "application/x-www-form-urlencoded";
    request.ContentLength = data.Length;
    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    using (var stream = request.GetRequestStream())
    {
        stream.Write(data, 0, data.Length);
    }
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    WebHeaderCollection header = response.Headers;
    var encoding = ASCIIEncoding.ASCII;
    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
    {
        string responseText = reader.ReadToEnd();
        System.Windows.Forms.MessageBox.Show(responseText);
    }
