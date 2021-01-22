    bool completed = false;
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
    try
    {
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                completed = true;
            }
        }
    }
    catch (Exception)
    {
        //Just don't do anything. Retry after few seconds
    }
    return completed.ToString();
