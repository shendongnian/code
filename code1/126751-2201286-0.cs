    public class FileLoader
    {
      // ... Other code for FileLoader goes here
    
      public FileLoader(string propertiesFileNameAndPath)
      {
        // Load values from propertiesFile into _properties / _propertyValues
      }
    
      private _properties = new List<string>();
      private _propertyValues = new Dictionary<string, string>();
    
      public string[] Properties
      {
        // returning as an array stops your _properties being modified
        return _properties.ToArray();
      }
      public void UpdateProperty(string propertyName, string propertyValue)
      {
        if (propertyValues.ContainsKey(propertyName))
        {
          propertyValues[propertyName] = propertyValue;
        }
      }
      public string GetPropertyValue(string propertyValue)
      {
        if (propertyValues.ContainsKey(propertyName))
        {
          return propertyValues[propertyName];
        }
      }
    }
