        public void MyMethod()
        {
            SettingsPropertyCollection MyAppProperties =
                Properties.Settings.Default.Properties;
            IEnumerator enumerator = MyAppProperties.GetEnumerator();
            object settingsDescriptionAttribute = null;
            // Iterate through all the keys to see what we have.... 
            while (enumerator.MoveNext())
            {
                SettingsProperty property = (SettingsProperty)enumerator.Current;
                ICollection myKeys = property.Attributes.Keys;
                foreach (object theKey in myKeys)
                {
                    System.Diagnostics.Debug.Print(theKey.ToString());
                    if (theKey.ToString() == "System.Configuration.SettingsDescriptionAttribute")
                        settingsDescriptionAttribute = theKey;
                }
            }
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                SettingsProperty property = (SettingsProperty)enumerator.Current;
                string propertyValue = property.DefaultValue.ToString();
                // This fails: Null Reference  
                string propertyDescription =
                    property.Attributes[settingsDescriptionAttribute].ToString();
                // Do stuff with strings... 
            }
        }
