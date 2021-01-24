    public void logPhoneCallDialog_SaveContact(Contact currentPhoneContact)
    {
        SaveContact(currentPhoneContact);
    }
    private void SaveContact(Contact currentPhoneContact)
    {
        if (currentPhoneContact != null)
        {
            RefreshRenewalActivity();
            // This code from your example doesn't compile.
            if (currentPhoneContact.TypeId == ResultType.TookAppointment)
        }
        NotifyServerOfActivity();
        ApplyAppointmentFilters();
        this.Activate();
        var messageProcessor = new MessageProcessor();
        messageProcessor.ProcessCustomerPhoneContactInfo(currentPhoneContact);
    }
