        using System;
        public static Action OnSignInSuccess;
    then inside your firebase asyncronous callback you can do:
            // ... within auth.SignInAnonymouslyAsync() callback
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
            userdataString = newUser.UserId;
            if(OnSignInSuccess != null)
                OnSignInSuccess.Invoke();
        }
    Then other scripts can subscribe and unsubscribe to this callback event with:
        void OnEnable(){
            YourScript.OnSignInSuccess += SignInSuccess;
        }
        void OnDisable(){
            YourScript.OnSignInSuccess -= SignInSuccess;
        }
        private void SignInSuccess(){
            Debug.Log("userdatastring: " + YourScript.staticInstance.userDataString);
        }
