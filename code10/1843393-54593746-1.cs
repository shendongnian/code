    public void on buttonPress()
    {
    
            Firebase.FirebaseApp.LogLevel = Firebase.LogLevel.Debug;
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                console.log('before if'); //log something here
                var dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    //transaction code
                    console.log('true')
                    return TransactionResult.Success(data);
                }
                else
                {
                    UnityEngine.Debug.LogError(System.String.Format(
                      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                    // Firebase Unity SDK is not safe to use here.
                }
                // firebase code is running, now change scene 
                SceneManager.LoadScene("blah");
            });
    }
