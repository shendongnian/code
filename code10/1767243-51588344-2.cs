    private bool HttpValidation(string URL)
    {
        Uri urlToCheck = new Uri(URL);
        WebRequest request = WebRequest.Create(urlToCheck);
        request.Timeout = 15000;
        WebResponse response;
        try
        {
            response = request.GetResponse();
        }
        catch (Exception)
        {
            return false; //url does not exist or have some error
        }
       
        return true;
    }
