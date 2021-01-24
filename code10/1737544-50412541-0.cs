    bool success = false;
    while (!success)
    {
        var rep = new HttpResponseMessage();
        try
        {
            rep = client.PostAsync("https://localhost:9999/", content).Result;
            //No exception here. Check your condition and set success = true if satisfied.
        }
        catch (Exception e)
        {
            //Log your exception if needed
        }
    }
