    var statusNumber;
    try {
       response = (HttpWebResponse)request.GetResponse();
       // This will have statii from 200 to 30x
       statusNumber = (int)response.StatusCode;
    }
    catch (WebException we) {
        // Statii 400 to 50x will be here
        statusNumber = (int)we.Response.StatusCode;
    }
