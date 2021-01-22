    catch(WebException e) {
        if(e.Status == WebExceptionStatus.ProtocolError) {
            var statusCode = (HttpWebResponse)e.Response).StatusCode);
            var description = (HttpWebResponse)e.Response).StatusDescription);
        }
    }
