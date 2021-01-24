    IMessageProcessorFactory _messageProcessorFactory;
    public TheConstructor(IMessageProcessorFactory processorFactory)
    {
        _messageProcessorFactory = processorFactory;
    }
    private void logPhoneCallDialog_SaveContact(Contact currentPhoneContact)
    {           
        if (currentPhoneContact != null)
        {
            RefreshRenewalActivity();
            if (currentPhoneContact.TypeId == ResultType.TookAppointment)
        }
        NotifyServerOfActivity();
        ApplyAppointmentFilters();
        this.Activate();
        var messageProcessor = _messageProcessorFactory.Create();
        messageProcessor.ProcessCustomerPhoneContactInfo(currentPhoneContact);
    }
