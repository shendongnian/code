    try
    {
        YourCommandWhichResultsInDeniedAccess();
    }
    catch (Exception e)
    {
       if (e.Message == 'Access Denied')
       {
           MessageBox.Show('Access Denied')
       }
    }
