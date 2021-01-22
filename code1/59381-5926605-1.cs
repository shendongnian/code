    public static bool isValidURL(string url) {
        WebRequest webRequest = WebRequest.Create(url);
        WebResponse webResponse;
        try
        {
            webResponse = webRequest.GetResponse();
        }
        catch //If exception thrown then couldn't get response from address
        {
            return false ;
        }
        return true ;
    }
