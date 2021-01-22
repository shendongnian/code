    foreach(var propertyValue in newHire.GetProperties())
    {
    string propName = propertyValue.Name;
    
    string postedValue = newHire.GetType().GetProperty(propName).GetValue(newHire, null).ToString();
    
    }
