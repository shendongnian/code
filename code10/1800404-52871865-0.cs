    var dateEncodedPropertyName = "System.Media.DateEncoded";
    var propertyNames = new List<string>()
    {
        dateEncodedPropertyName
    };
    // Get extended properties
    IDictionary<string, object> extraProperties =
        await file.Properties.RetrievePropertiesAsync(propertyNames);
    // Get the property value
    var propValue = extraProperties[dateEncodedPropertyName];
    if (propValue != null)
    {
        Debug.WriteLine(propValue);
    }
