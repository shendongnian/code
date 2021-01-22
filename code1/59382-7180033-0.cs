    /// <summary>
    /// This method will check a url to see that it does not return anything other than a HttpStatus of 200 (OK)
    /// </summary>
    /// <param name="url">The path to check</param>
    /// <returns></returns>
    public bool UrlIsValid(string url)
    {
        try
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Timeout = 5000; //set the timeout to 5 seconds to keep the user from waiting too long for the page to load
            request.Method = "HEAD"; //Get only the header information -- no need to download any content
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            return (response.StatusCode == HttpStatusCode.OK);
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError) //400 errors are found here, GetResponse throws exception on 400 errors
            {
                return false;
            }
            else
            {
                log.Warn(String.Format("Unhandled status [{0}] returned for url: {1}", ex.Status, url), ex);
            }
        }
        catch (Exception ex)
        {
            log.Error("Could not test url. An application error has occurred.", ex);
        }
        return false;
    }
