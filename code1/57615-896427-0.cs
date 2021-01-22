    foreach (LevelButton l in ls)
    {
        LevelButton tmp = l;
        var client=new SilverlightNav.WayFinderDBService.WayFinderDBServiceClient();
        client.GetLevelDescriptionCompleted += delegate (object sender, GetLevelDescriptionCompletedEventArgs args) {
           tmp.Text = args.SomeProperty; // **must** be tmp.Text, not l.Text
        }
        client.GetLevelDescriptionAsync(tmp.Name); // or l.Name; same here
    }
