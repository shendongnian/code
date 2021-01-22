    //Done with the service, let's close it.
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
