    DirectoryEntry entry = new DirectoryEntry(
            "LDAP://CN=Schema,CN=Configuration,DC=domain,DC=local",
            null, null, AuthenticationTypes.Secure);
    
    ActiveDirectorySchema schema = ActiveDirectorySchema.GetCurrentSchema();
    // below code retrieves Active Directory Domain Services class "User" in the schema.
    ActiveDirectorySchemaClass user = schema.FindClass("User");
    
    foreach (ActiveDirectorySchemaProperty property in user.GetAllProperties())
    {
        Console.WriteLine("{0}", property.Name);
    }
