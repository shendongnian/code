    public async Task WithAll(Func<Profile, Task> profileAsync, CancellationToken cancellationToken) {
        var asyncEnumerable = (IDbAsyncEnumerable<Profile>)db.Profiles.AsNoTracking()
                                .Where(i => i.IsDeleted == 0);
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
