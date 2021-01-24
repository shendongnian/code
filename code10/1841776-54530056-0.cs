    boolean success = false;
    while (!success) {
        try
        {
            using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "Some URL"))
            {
                requestMessage.Headers.Add("Accept", "application/json");                                
                response = await myHttpHelper.SendHttpRequest(requestMessage).ConfigureAwait(false);                             
            }
            success = true; <--- set to true here
        }
        ...
    }
