    var changes = R.Db(DbName).Table(TableName)
        //.changes()[new {include_states = true, include_initial = true}]
        .Changes()
        .RunChanges<JObject>(conn);
    changes.IsFeed.Should().BeTrue();
    var observable = changes.ToObservable();
    //use a new thread if you want to continue,
    //otherwise, subscription will block.
    observable.SubscribeOn(NewThreadScheduler.Default)
        .Subscribe(
            x => OnNext(x),
            e => OnError(e),
            () => OnCompleted()
        );
