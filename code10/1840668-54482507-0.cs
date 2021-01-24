    List<string> Properties = null;
    foreach (DUIElement item in selecteditems)
    {
        // Check for first iteration
        if (Properties == null)
        {
            // Get name of properties from first iteration
            Properties = new List<string>();
            foreach (PropertyInfo item in item.GetType().GetProperties().ToList<PropertyInfo>())
                Properties.Add(item.Name);
        }
        else
        {
            // Check properties from current iteration
            foreach (PropertyInfo property in item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                // Remove properties where they do not exist in current property list
                if (!Properties.Contains(property.Name))
                    Properties.Remove(property.Name);
            }
        }
    }
