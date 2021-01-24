    public IEnumerator FacebookLogin()
    {
        //5 seconds loggout time
        float waitTimeOut = 5f;
        //Log out if loggedin
        if (FB.IsLoggedIn)
            FB.LogOut();  //it doesn't work, user is still logged in
        //Wait until logout is done. Also add a timeout to the wait so that it doesnt wait forever
        float timer = 0;
        while (FB.IsLoggedIn)
        {
            if (timer > waitTimeOut)
            {
                Debug.LogError("Failed to log out within " + waitTimeOut + " seconds");
                yield break;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Successfully logged out. Now logging another user in");
        var permissions = new List<string>() { "email" };
        FB.LogInWithReadPermissions(permissions);  //trying
    }
