    #if(DEBUG)
    				//Verify that the Property has the required attribute for Binary serialization.
    				System.Reflection.PropertyInfo binarySerializeProperty = Properties.Settings.Default.GetType().GetProperty("SettingName");
    				object[] customAttributes = binarySerializeProperty.GetCustomAttributes(typeof(System.Configuration.SettingsSerializeAsAttribute), false);
    				if (customAttributes.Length != 1)
    				{
    					throw new ApplicationException("SettingsSerializeAsAttribute required for SettingName property");
    				}
    #endif
