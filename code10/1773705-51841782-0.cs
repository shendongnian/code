    Retrier.Retry(3, 10, typeof(NodeIsOutOfDateException), () =>
    {
       // execute something that may throw a NodeIsOutOfDateException
       var currentUser = Node.Load(User.Current.Id);
       currentUser["ExtensionData"] = strNow;
       currentUser.Save();
    });
