        public void MyMethod()
        {
            SettingsPropertyCollection MyAppProperties = 
                Properties.Settings.Default.Properties;
    
            IEnumerator enumerator = MyAppProperties.GetEnumerator();
    
            // Iterate through all the keys to see what we have....
            while (enumerator.MoveNext())
            {
                SettingsProperty property = (SettingsProperty)enumerator.Current;
                ICollection myKeys = property.Attributes.Keys;
    
                foreach (object theKey in myKeys)
                {
                    if (property.Attributes[theKey].GetType().Name == "SettingsDescriptionAttribute")
                    {
                        SettingsDescriptionAttribute sda = property.Attributes[theKey] as SettingsDescriptionAttribute;
                        System.Diagnostics.Debug.Print(sda.Description); // prints the description
                    }
                }
            }
    
        }
