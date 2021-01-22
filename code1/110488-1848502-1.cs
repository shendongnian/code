    private void UpdateSharePointFromInfoPath(Hashtable infopathFields)
    {
        // Go through all the fields on the infopath form
        // Invalid Cast Exception Here
        foreach (object key in infopathFields.Keys)
        {
            
            string wfpKey = key.ToString();
            // If the same field is on sharepoint    
            if (workflowProperties.Item.Fields.ContainsField(wfpKey))
            {
                // Update the sharepoint field with the new value from infopath
                workflowProperties.Item[wfpKey] = infopathFields[key];
            }
        }
        // Commit the changes
        workflowProperties.Item.Update();
    }
