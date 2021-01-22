    var bll = Resolve();
    Task.Factory.StartNew(_ => bll.Login("name", "pass"))
      .ContinueWith(task =>
      {
        // Note: accessing Result will raise any exceptions thrown by Login
        User userBO = task.Result;
        ...
      }, ui);
