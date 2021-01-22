    private string UrlLengthen(string url)
    {
        string newurl = url;
        bool redirecting = true;
        while (redirecting)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newurl);
                request.AllowAutoRedirect = false;
                request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.3) Gecko/20090824 Firefox/3.5.3 (.NET CLR 4.0.20506)";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if ((int)response.StatusCode == 301 || (int)response.StatusCode == 302)
                {
                    string uriString = response.Headers["Location"];
                    Log.Debug("Redirecting " + newurl + " to " + uriString + " because " + response.StatusCode);
                    newurl = uriString;
                    // and keep going
                }
                else
                {
                    Log.Debug("Not redirecting " + url + " because " + response.StatusCode);
                    redirecting = false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("url", newurl);
                Exceptions.ExceptionRecord.ReportWarning(ex); // change this to your own
                redirecting = false;
            }
        }
        return newurl;
    }
