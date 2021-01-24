    for (int i = 0; i < 3; i++)
    {
        try
        {
            using (HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "Some URL"))
            {
                requestMessage.Headers.Add("Accept", "application/json");                                
                response = await myHttpHelper.SendHttpRequest(requestMessage).ConfigureAwait(false);                             
            }
        }
        catch (TaskCanceledException)
        {
            Thread.Sleep(10000);
        }
        catch (Exception ex2)
        {
            throw;
        }
    }
