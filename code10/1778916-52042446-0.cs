    private void HandleDbException(Action action)
    {
        try
        {
            action();
        }
        catch (Exception e)
        {
           SaveExceptionInDatabase(e, DateTime.now(), CurrentUser);
           ShowFriendlyNotification();
        }
    }
