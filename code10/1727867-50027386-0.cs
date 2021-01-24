    public static bool HasErrorResponse(HttpWebRequest request, out WebResponse response)
    {
        try
        {
            response = request.GetResponse();
            return true;
        }
        catch (WebException ex)
        {
            return false;
        }
    }
