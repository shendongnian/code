    public List<doubleVariableDateAndName> GetReminderList()
    {
       var userDefaults = NSUserDefaults.StandardUserDefaults;
       var serializedContent = userDefaults.StringForKey("yourUniqueIdentifier");
       if (!string.IsNullOrEmpty(serializedContent ))
       {
          var reminderList = JsonConvert.DeserializeObject<List<doubleVariableDateAndName>>(serializedContent);
          return reminderList;
       }
    
       return null;
    }
