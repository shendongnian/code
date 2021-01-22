    private void SetCategoryLabelViaReflection(GridItem category,
                                               string oldCategoryName,
                                               string newCategoryName)
    {
        try
        {
            Type t = category.GetType();
            FieldInfo f = t.GetField("name",
                                     BindingFlags.NonPublic | BindingFlags.Instance);
            if (f.GetValue(category).Equals(oldCategoryName))
            {
                f.SetValue(category, newCategoryName);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.Write("Failed Renaming Category: " + ex.ToString());
        }
    }
