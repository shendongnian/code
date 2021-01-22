    using (var resp = myRequest.GetResponse())
    {
        using (var responseStream = resp.GetResponseStream())
        {
            using (var responseReader = new StreamReader(responseStream))
            {
            }
        }
    }
