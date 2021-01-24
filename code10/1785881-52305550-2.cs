    FirebaseDatabase.DefaultInstance
      .GetReference("Leaders")
      .GetValueAsync().ContinueWith(task => {
        if (task.IsFaulted) {
          // Handle the error...
        }
        else if (task.IsCompleted) {
          DataSnapshot snapshot = task.Result;
          // Do something with snapshot...
        }
      });
