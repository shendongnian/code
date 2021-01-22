    try
    {
        if (ContentUrl != "")
        {
            string imgExtension = ContentUrl.Substring(ContentUrl.Length - 3, 3);
            switch (imgExtension)
            {
                case "":
                    //image/bmp
                    Response.ContentType = "image/bmp";
                    break;
                case "jpg":
                    //image/jpeg
                    Response.ContentType = "image/jpeg";
                    break;
                case "gif":
                    //image/gif
                    Response.ContentType = "image/gif";
                    break;
                default:
                    Response.ContentType = "image/jpeg";
                    break;
            }
            if (!ContentUrl.StartsWith("http"))
                Response.BinaryWrite(new byte[] { 0 });
            WebClient wc = new WebClient();
            wc.Credentials = System.Net.CredentialCache.DefaultCredentials;
            Byte[] result;
            result = wc.DownloadData(ContentUrl);
            Response.BinaryWrite(result);
            
        }
    }
    catch (Exception ex)
    {
        Utility.WriteEventError(Utility.EVENTLOG_SOURCE, string.Format("ImageProxy Error... Url:  {0}, Exception: {1}", ContentUrl, ex.ToString()));
    }
    finally
    {
        Response.End();
    }
