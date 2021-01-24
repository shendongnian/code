    List<UserScore> leaderBoard = new List<UserScore>();
    db.Child("users").Child(uid).Child("friendList").GetValueAsync().ContinueWith(task => {
        if (task.IsCompleted)
        {
            //foreach friend
            foreach(DataSnapshot h in task.Result.Children)
            {
                // kick off the task to retrieve friend's name
                Task nameTask = db.Child("users").Child(h.Key).Child("name").GetValueAsync();
                // kick off the task to retrieve friend's score
                Task scoreTask = db.Child("scores").Child(h.Key).GetValueAsync();
                // join tasks into one final task
                Task finalTask = Task.Factory.ContinueWhenAll((new[] {nameTask, scoreTask}), tasks => {
                  if (nameTask.IsCompleted && scoreTask.IsCompleted) {
                    // both tasks are complete; add new record to leaderboard
                    string name = nameTask.Result.Value.ToString();
                    int score = int.Parse(scoreTask.Result.Value.ToString());
                    leaderBoard.Add(new UserScore(name, score));
                    Debug.Log(name);
                    Debug.Log(score.ToString());
                  }
                })
            }
        }
    });
