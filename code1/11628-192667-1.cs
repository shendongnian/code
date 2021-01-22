    public bool doesImageExistRemotely(string uriToImage, string mimeType)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriToImage);
        request.Method = "HEAD";
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK && response.ContentType == mimeType)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }
        catch
        {
            return false;
        }
    }
