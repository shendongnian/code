    using (DirectoryEntry entry = new DirectoryEntry())
    {
        entry.Username = "here goes the username you want to validate";
        entry.Password = "here goes the password";
        DirectorySearcher searcher = new DirectorySearcher(entry);
        searcher.Filter = "(objectclass=user)";
    
        try
        {
            searcher.FindOne();
        }
        catch (COMException ex)
        {
            if (ex.ErrorCode == -2147023570)
            {
                // Login or password is incorrect
            }
        }
    }
    
    // FindOne() didn't throw, the credentials are correct
