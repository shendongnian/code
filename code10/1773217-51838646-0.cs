        var isApplicationInstalled = ApplicationContext.Current.IsConfigured &&
                                        ApplicationContext.Current.DatabaseContext.CanConnect;
        if (isApplicationInstalled)
        {
            // run the task
        }
