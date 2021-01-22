    DateTime dateTime;
    if (DateTime.TryParse(value, out dateTime))
    {
        lastSyncDate = String.Format(CultureInfo.InvariantCulture,"{0:G}", dateTime);
    }
    else
    {
        HandleInvalidInput(value);
    }
