    FirebaseDatabase.DefaultInstance
      .GetReference("Leaders")
      .GetValueAsync().ContinueWith(task =&gt {
        if (task.IsFaulted) {
          // Handle the error...
        }
        else if (task.IsCompleted) {
          DataSnapshot snapshot = task.Result;
          // Do something with snapshot...
        }
      });
