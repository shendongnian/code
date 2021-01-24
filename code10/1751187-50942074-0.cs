    DirectoryEntry entry = new DirectoryEntry(
            "LDAP://CN=Schema,CN=Configuration,DC=addomain,DC=com",
            null, null, AuthenticationTypes.Secure);
    
    ActiveDirectorySchema schema = ActiveDirectorySchema.GetCurrentSchema();
    
    // below code retrieves all Active Directory Domain Services classes in the schema.
    ReadOnlyActiveDirectorySchemaClassCollection collection = schema.FindAllClasses();
    // Now you can iterate over the collection Items.
    foreach (ActiveDirectorySchemaClass schemaClass in collection)
       {
           foreach (ActiveDirectorySchemaProperty property in schemaClass.GetAllProperties())
              {
                  Console.WriteLine("{0}", property.Name);
              }
       }
