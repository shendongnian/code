    public static string LoadTemplateFile(
        string fileName, NameValueCollection  mergeFields)
    {    
        System.Text.StringBuilder result = new System.Text.StringBuilder(
            System.IO.File.ReadAllText(fileName));
        if (mergeFields != null)
        {
            for (int index = 0; index < mergeFields.Count; index++)
            {
                result.Replace(mergeFields.Keys[index], 
                                        mergeFields[index]);
            }
        }
    
        return result.ToString();
    }
