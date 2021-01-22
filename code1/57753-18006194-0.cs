    protected override System.Net.WebRequest GetWebRequest(Uri uri)
    {
            HttpWebRequest request;
            request = (HttpWebRequest)base.GetWebRequest(uri);
            NetworkCredential networkCredentials =
            Credentials.GetCredential(uri, "Basic");
            if (networkCredentials != null)
            {
                byte[] credentialBuffer = new UTF8Encoding().GetBytes(
                networkCredentials.UserName + ":" +
                networkCredentials.Password);
                request.Headers["Authorization"] =
                "Basic " + Convert.ToBase64String(credentialBuffer);
                request.Headers["Cookie"] = "BCSI-CS-2rtyueru7546356=1";
                request.Headers["Cookie2"] = "$Version=1";
            }
            else
            {
                throw new ApplicationException("No network credentials");
            }
            return request;
    }
