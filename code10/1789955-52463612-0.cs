    static public bool RunWordDocumentAddProperties(string filePath, List<string> strName, List<string> strVal)
    {
        bool is_ok = true;
        try
        {
            if (File.Exists(filePath) == false)
                return false;                
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, true))
            {
                var customProps = wordDoc.CustomFilePropertiesPart;
                if (customProps == null)
                {
                    // no custom properties? Add the part, and the collection of properties
                    customProps = wordDoc.AddCustomFilePropertiesPart();
                    customProps.Properties = new DocumentFormat.OpenXml.CustomProperties.Properties();
                }
                for (byte b = 0; b < strName.Count; b++)
                {
                    var props = customProps.Properties;                        
                    if (props != null)
                    {
                        var newProp = new CustomDocumentProperty();
                        newProp.VTLPWSTR = new VTLPWSTR(strVal[b].ToString());
                        newProp.FormatId = "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}";
                        newProp.Name = strName[b];
                        // append the new property, and fix up all the property ID values
                        // property ID values must start at 2
                        props.AppendChild(newProp);
                        int pid = 2;
                        foreach (CustomDocumentProperty item in props)
                        {
                            item.PropertyId = pid++;
                        }
                        props.Save();
                    }
                }                    
            }
        }
        catch (Exception ex)
        {
            is_ok = false;
            ProcessError(ex);
        }
        return is_ok;
    }
