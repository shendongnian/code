    //AuthenticatedUser is a class in the mobile app.
    
    public void RegisterWithNotificationServer(AuthenticatedUser savedUser)
            {
                string token = FirebaseInstanceId.Instance.Token;
                  
                string customerNotificationTag = "customerid:" + savedUser.CustomerNotificationTagID;
                string userNotificationTag = "userid:" + savedUser.UserNotificationTagID;
    
    	    //Hub variable defined with class scope.            
                hub = new NotificationHub(Constants.NotificationHubName, Constants.ListenConnectionString, this);
                
                List<string> tags = new List<string>() { customerNotificationTag, userNotificationTag };
                Registration registration = hub.Register(token, tags.ToArray());
                string regID = registration.RegistrationId;
    
            }
