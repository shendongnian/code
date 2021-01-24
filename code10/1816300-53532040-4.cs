    var hasAccess = await BackgroundExecutionManager.RequestAccessAsync();
    if (hasAccess == BackgroundAccessStatus.DeniedBySystemPolicy 
        || hasAccess == BackgroundAccessStatus.DeniedByUser
        || hasAccess == BackgroundAccessStatus.Unspecified)
    {
        await new MessageDialog("ACCESS DENIED").ShowAsync();
        return;
    }
    
    /////////////////////begin registering bg task
    var task = new BackgroundTaskBuilder
    {
        Name = "Background",
        TaskEntryPoint = typeof(Background.BackgroundTask).ToString()
    };
    
    //Trigger is necessary for registering bg tasks but Conditions are  optional
    //set a trigger for your bg task to run 
    //for ex. below Trigger will run when toast Notifications (cleared, user pressed an action button and so on)
    ToastNotificationActionTrigger actiontrigger = new ToastNotificationActionTrigger();
    
    task.SetTrigger(actiontrigger);
    
    //Optional Conditions like Internet Connection
    //var condition = new SystemCondition(SystemConditionType.InternetAvailable);
    
    //task.AddCondition(condition);//set condition
    
    BackgroundTaskRegistration registration = task.Register();//Register the task
