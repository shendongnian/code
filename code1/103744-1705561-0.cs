    ClientStatus clientStatus = client.GetStatus();
    try
    {
        if (client.State != System.ServiceModel.CommunicationState.Faulted)
        {
             client.Close();
        }
    }
    catch (Exception ex)
    {
        client.Abort();
    }
