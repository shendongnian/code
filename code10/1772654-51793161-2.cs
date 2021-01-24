    public void logPhoneCallDialog_SaveContact(Contact currentPhoneContact)
    {
        var messageProcessor = new MessageProcessor();
        SaveContact(currentPhoneContact, messageProcessor);
    }
    public void SaveContact(
        Contact currentPhoneContact,
        IMessageProcessor messageProcessor)
    {
        if (currentPhoneContact != null)
        {
            RefreshRenewalActivity();
            if (currentPhoneContact.TypeId == ResultType.TookAppointment)
        }
        NotifyServerOfActivity();
        ApplyAppointmentFilters();
        this.Activate();
        messageProcessor.ProcessCustomerPhoneContactInfo(currentPhoneContact);
    }
