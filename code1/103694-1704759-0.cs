    static T GetResponse<T>(HttpWebRequest request)
    {
        HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
        try
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(resp.GetResponseStream());
         }
        catch(Exception e)
        {
            error =  e.InnerException.ToString();
            return null;
        }
    }
