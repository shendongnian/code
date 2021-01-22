    // after getting the "PageItem" database records into a "pageItems" array
    foreach (PageItem p in pageItems)
    {
        // get the type and properties
        Type controlType = System.Type.GetType(p.DisplayControl)
        PropertyInfo[] controlPropertiesArray = controlType.GetProperties();
        // create the object
        object control = Activator.CreateInstance(controlType);
        // look for matching property
        foreach (PropertyInfo controlProperty in controlPropertiesArray)
        {
            if (controlPropertiesArray.Name == p.DisplayProperty)
            {
                // set the Control's property
                controlProperty.SetValue(control, "data for this item", null);
            }
        }
        // then generate the control on the page using LoadControl (sorry, lacking time to look that up)
