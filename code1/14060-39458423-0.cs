     var client = new System.Net.WebClient();
     var data = client.DownloadData(url);
     var encoding = System.Text.Encoding.Default;
     var contentType = new System.Net.Mime.ContentType(client.ResponseHeaders[HttpResponseHeader.ContentType]);
     if (!String.IsNullOrEmpty(contentType.CharSet))
     {
          encoding = System.Text.Encoding.GetEncoding(contentType.CharSet);
     }
     string result = encoding.GetString(data);
