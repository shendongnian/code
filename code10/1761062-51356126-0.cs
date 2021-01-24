    DatabaseReference rootReference = FirebaseDatabase.DefaultInstance.RootReference;
    DatabaseReference childToRemove = rootReference.Child("your child path");
    
    childToRemove.RemoveValueSync().ContinueWith(
                (task) =>
                {
                    if (task.IsCanceled || task.IsFaulted) Debug.Log("Fail");
                    else if (task.IsCompleted) Debug.Log("Success");
                });
