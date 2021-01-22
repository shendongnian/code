    public class MyInvestigatorClass
    {
        public void InvestigateTheAttribute()
        {
            // Get the type object for the class that is using
            // the attribute.
            Type type = typeof(MyClass);
            // Get all custom attributes for the type.
            object[] attributes = type.GetCustomAttributes(
                typeof(SortOrderAttribute), true);
            // Now let's make sure that we got at least one attribute.
            if (attributes != null && attributes.Length > 0)
            {
                // Get the first attribute in the list of custom attributes
                // that is of the type "SortOrderAttribute". This should only
                // be one since we said "AllowMultiple=false".
                SortOrderAttribute attribute = 
                    attributes[0] as SortOrderAttribute;
                // Now we can get the sort order for the class "MyClass".
                int sortOrder = attribute.SortOrder;
            }
        }
    }
