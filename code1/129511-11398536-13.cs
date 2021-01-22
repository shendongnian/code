    /// <summary>
    /// Must override this, this is the bit that matches up the designer properties to the dictionary values
    /// </summary>
    /// <param name="context"></param>
    /// <param name="collection"></param>
    /// <returns></returns>
    public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
    {
        //collection that will be returned.
        SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();
    
        //iterate thought the properties we get from the designer, checking to see if the setting is in the dictionary
        foreach (SettingsProperty setting in collection)
        {
            SettingsPropertyValue value = new SettingsPropertyValue(setting);
            value.IsDirty = false;
    
            //need the type of the value for the strong typing
            var t = Type.GetType(setting.PropertyType.FullName);
    
            if (SettingsDictionary.ContainsKey(setting.Name))
            {
                value.SerializedValue = SettingsDictionary[setting.Name].value;
                value.PropertyValue = Convert.ChangeType(SettingsDictionary[setting.Name].value, t);
            }
            else //use defaults in the case where there are no settings yet
            {
                value.SerializedValue = setting.DefaultValue;
                value.PropertyValue = Convert.ChangeType(setting.DefaultValue, t);
            }
    
                values.Add(value);
        }
        return values;
    }
    
    /// <summary>
    /// Must override this, this is the bit that does the saving to file.  Called when Settings.Save() is called
    /// </summary>
    /// <param name="context"></param>
    /// <param name="collection"></param>
    public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
    {
        //grab the values from the collection parameter and update the values in our dictionary.
        foreach (SettingsPropertyValue value in collection)
        {
            var setting = new SettingStruct()
            {
                value = (value.PropertyValue == null ? String.Empty : value.PropertyValue.ToString()),
                name = value.Name,
                serializeAs = value.Property.SerializeAs.ToString()
            };
        
            if (!SettingsDictionary.ContainsKey(value.Name))
            {
                SettingsDictionary.Add(value.Name, setting);
            }
            else
            {
                SettingsDictionary[value.Name] = setting;
            }
        }
    
        //now that our local dictionary is up-to-date, save it to disk.
        SaveValuesToFile();
    }
