    [HttpPost]
    public IActionResult ProcessPushNotification(PushRequest push)
    {
        using(var scope = UserScopeLocker.Acquire(push.UserId))
        {
            // process the push notification
            // two threads can't enter here for the same UserId
            // the second one will be blocked until the first disposes
        }
    }
