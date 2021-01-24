    using CredentialManagement;
    using (CredentialSet credentials = new CredentialSet())
    {
        Debug.Print(credentials.Count.ToString() + " credential(s) found.");
        foreach (Credential credential in credentials)
        {
            Debug.Print(credential.Target); //This is domain/IP of the saved credential.
            Debug.Print(credential.Type.ToString());
            Debug.Print(credential.Username);
            Debug.Print(credential.PersistanceType.ToString());
            Debug.Print(credential.Description);
            Debug.Print(credential.LastWriteTime.ToString());
        }
        Debug.Print("End");
    }
