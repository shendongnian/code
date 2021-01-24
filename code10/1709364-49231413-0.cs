    catch (WebException wbEx)
    {
        if (wbEx.Status == WebExceptionStatus.ProtocolError)
        {
            if (wbEx.Response is HttpWebResponse response)
            {
                returnStatusCode = (int) response.StatusCode;
            }
            else // should not happen
            {
                returnStatusCode = -1;
            }
        }
        else
        {
            if (wbEx.Status == WebExceptionStatus.Timeout)
            {
                returnStatusCode = 408; // now this is not right because this is CLIENT timeout.
            }
        }
    }
    catch
    {
        returnStatusCode =  -1;
    }
