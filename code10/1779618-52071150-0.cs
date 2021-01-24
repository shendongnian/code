    public async Task WithAll(Action<Task<Profile>> profile, CancellationToken cancellationToken) {
        var asyncEnumerable = db.Profiles.AsNoTracking()
                                .Where(i => i.IsDeleted == 0)
                                .AsDbAsyncEnumerable<T>();
        using (var enumerator = asyncEnumerable.GetAsyncEnumerator())
        {
            if (await enumerator.MoveNextAsync(cancellationToken)
                    .ConfigureAwait(continueOnCapturedContext: false))
            {
                Task<bool> moveNextTask;
                do
                {
                    var current = enumerator.Current;
                    moveNextTask = enumerator.MoveNextAsync(cancellationToken);
                    await action(current); //now with await
                }
                while (await moveNextTask.ConfigureAwait(continueOnCapturedContext: false));
            }
        }
    }
