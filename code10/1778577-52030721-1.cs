    private Domain GetStatus(string x)
    {
        string status = "";
        try
        {    
             WebRequest req = HttpWebRequest.Create("http://www." + x);
             WebResponse res = req.GetResponse();
             HttpWebResponse response = (HttpWebResponse)res;
             if ((int)response.StatusCode > 226 || 
                 response.StatusCode ==  HttpStatusCode.NotFound)
             {
                 status = "ERROR: " + response.StatusCode.ToString();
             }
             else
             {
                 status = "LIVE";
             }
         }
         catch (Exception e)
         {
              status = "ERROR: Something bad happend: " + e.ToString();
         }
       
         Domain temp = new Domain(x, status);
         return temp;
    }
