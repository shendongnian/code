    try
    {
        YourCommandWhichResultsInDeniedAccess();
    }
    catch (AccessDeniedException)
    {
        MessageBox.Show('Access Denied');
    }
