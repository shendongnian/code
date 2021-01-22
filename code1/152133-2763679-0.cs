        if(client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
        {
           // call service - everything's fine
        }
        else
        {
           // channel faulted - re-create your client and then try again
        }
