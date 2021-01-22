    public bool IsAddressResponsive(string Address)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Address);
        req.Method = "GET";
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        if (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Accepted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
