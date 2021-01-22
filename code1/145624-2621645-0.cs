    if (_Host.State == CommunicationState.Faulted)
    {
        _Host.Abort();
    }
    else
    {
        _Host.Close();
    }
     
