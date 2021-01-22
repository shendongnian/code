    var calendar = _session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
    var userProperties = calendar.UserDefinedProperties;
    var prop = userProperties.Find("PropName");
    {
        if (prop  == null)
            userProperties.Resource.Add("PropName", OlUserPropertyType.olText);
    }
