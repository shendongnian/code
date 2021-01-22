    private void InnerChannel_Error(object sender, EventArgs e)
    {
        var svc = _entrepotService as EntrepotServiceProxy;
        try
        {
            if (svc != null)
            {
                if (svc.State != CommunicationState.Faulted)
                {
                    svc.Close();
                }
                else
                {
                    svc.Abort();
                }
            }
        }
        catch (CommunicationException)
        {
            if (svc != null) svc.Abort();
        }
        catch (TimeoutException)
        {
            if (svc != null) svc.Abort();
        }
        catch
        {
            if (svc != null) svc.Abort();
            throw;
        }
        _entrepotService = new EntrepotServiceProxy();
    }
