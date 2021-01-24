    public Dictionary<string, ActiveDirectorySyntax> GetAttributeSyntaxes(List<string> lstAttributeNames)
    {
        Dictionary<string, ActiveDirectorySyntax> dictRes = new Dictionary<string, ActiveDirectorySyntax>();
        if (lstAttributeNames.Count > 0)
        {
            DirectoryContext directoryContext = new DirectoryContext(DirectoryContextType.DirectoryServer,
                                                                 m_Server, m_UserName, m_Password);
            using (ActiveDirectorySchema currentSchema = ActiveDirectorySchema.GetSchema(directoryContext))
            {
                using (ActiveDirectorySchemaClass objClass = currentSchema.FindClass("user"))
                {
                    if (objClass != null)
                    {
                        ReadOnlyActiveDirectorySchemaPropertyCollection propcol = objClass.GetAllProperties();
                        foreach (ActiveDirectorySchemaProperty schemaProperty in propcol)
                        {
                            foreach (string attrName in lstAttributeNames)
                            {
                                if (schemaProperty.Name.Equals(attrName))
                                {                                    
                                    dictRes.Add(attrName, schemaProperty.Syntax);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        return dictRes;
    }
