    public void FillAddress(string type)
    {
        if (_addressDetails == null) throw new Exception($"{nameof(_addressDetails)} must not be null.");
        dynamic details = _addressDetails;
        dynamic addressSource;
        if (type == "Manager")
        {
            addressSource = _manager;
        }
        else if (type == "TeamLead")
        {
            addressSource = _teamLead;
        }
        else if (type == "Employee")
        {
            addressSource = _employee;
        }
        else
        {
            throw new ArgumentException("Unrecognized type", nameof(type));
        }
        details.AddressLine1 = addressSource.AddressLine1;
        details.AddressLine2 = addressSource.AddressLine2;
        details.AddressLine3 = addressSource.AddressLine3;
    }
