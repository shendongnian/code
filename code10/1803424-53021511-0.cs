    public void FacebookLogin()
        {
                if (FB.IsLoggedIn)
                 {   
                  FB.LogOut();  //it doesn't work, user is still logged in
                  return;
                 }
                  var permissions = new List<string>() {"email"};
                  FB.LogInWithReadPermissions(permissions);  //t
        }
            
                 
