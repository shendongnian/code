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
            int statusCode = (int)response.StatusCode;
            if (statusCode >= 100 && statusCode < 400) //Good requests
            {
                return true;
            }
            else if (statusCode >= 500 && statusCode <= 510) //Server Errors
            {
                log.Warn(String.Format("The remote server has thrown an internal error. Url is not valid: {0}", url));
                return false;
            }
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError) //400 errors
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
            log.Error(String.Format("Could not test url {0}.", url), ex);
        }
        return false;
    }        if (statusCode >= 100 && statusCode < 400) //Good requests
            {
                return true;
            }
            else if (statusCode >= 500 && statusCode <= 510) //Server Errors
            {
                log.Warn(String.Format("The remote server has thrown an internal error. Url is not valid: {0}", url));
                return false;
            }
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError) //400 errors
            {
                return false;
            }
            else
            {
                log.Warn(String.Format("Unhandled status [{0}] returned from SEOService.UrlIsValid for url: {1}", ex.Status, url), ex);
            }
        }
        catch (Exception ex)
        {
            log.Error("Could not test redirect url in SEOService.", ex);
        }
        return false;
    }
