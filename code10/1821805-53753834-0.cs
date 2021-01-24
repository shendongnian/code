    FirebaseDatabase.DefaultInstance
               .GetReference("Leaders").OrderByChild("Score")
               .GetValueAsync().ContinueWith(task =>
               {
                   if (task.IsFaulted)
                   {
                       Debug.LogError("Get faulted");
                       return;
                   }
                   if (task.Result != null && task.Result.ChildrenCount > 0)
                   {
                       Debug.Log("Get data success!");
                       ...
                   }
               });
