    foreach (SearchResult searchResult in allResults)
    {
      foreach (string propName in searchResult.Properties.PropertyNames)
      {
        ResultPropertyValueCollection valueCollection =
        searchResult.Properties[propName];
        foreach (Object propertyValue in valueCollection)
        {
    	Console.WriteLine("Property: " + propName + ": " + propertyValue.ToString());
        }
      }
    }
