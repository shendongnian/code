    try
    {
        ...
        client.Close();
    }
    catch (CommunicationException e)
    {
        ...
        client.Abort();
    }
    catch (TimeoutException e)
    {
        ...
        client.Abort();
    }
    catch (Exception e)
    {
        ...
        client.Abort();
        throw e;
    }
