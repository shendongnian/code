    public void ValidationError(string fieldName, string message = null)
    {
        string realMessage = message ?? ValidationMessages.ContactNotFound;
        ...
    }
