    AppendProperties(_gridModel, item, "Header", "Width", "Align", ...)
    void AppendProperty(object gridmodel, object item, params string[] propNames)
    {
        foreach (string propName in propNames)
            AppendProperties(gridmodel, item, propName);
    }
    void AppendProperties(object gridmodel, object item, string propName)
    {
        PropertyInfo piGrid = gridmodel.GetType().GetProperty(propName);
        if (piGrid != null && piGrid.PropertyType == typeof(string))
        {
            piGrid.SetValue(gridmodel, 
                piGrid.GetValue(gridmodel, null).ToString() + ",", null);
        }
        if (item == null) return;
        PropertyInfo piItem = item.GetType().GetProperty(propName);
        if (piItem != null)
        {
            piGrid.SetValue(gridmodel, 
                piGrid.GetValue(gridmodel, null).ToString() 
                + piItem.GetValue(item, null).ToString(), 
                null);
        }
    }
