    public void SaveList(List<doubleVariableDateAndName> reminderList)
    {
        var serializedContent = JsonConvert.SerializeObject(reminderList);
        NSUserDefaults.StandardUserDefaults.SetString(serializedContent ,"yourUniqueIdentifier");
    }
