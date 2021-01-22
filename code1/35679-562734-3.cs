    // populate colors drop down (will work with other kinds of list controls)
    Type colors = typeof(System.Drawing.Color);
    PropertyInfo[] colorInfo = colors.GetProperties(BindingFlags.Public |
        BindingFlags.Static);
    foreach ( PropertyInfo info in colorInfo)
    {
        ddlColor.Items.Add(info.Name);                
    }
    // Get the selected color
    System.Drawing.Color selectedColor = 
        System.Drawing.Color.FromName(ddlColor.SelectedValue);
