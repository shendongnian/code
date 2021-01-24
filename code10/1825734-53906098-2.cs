    public async IAsyncEnumerable<int> EnumerateAsync(CancellationToken cancellationToken) {
        for (int i = 0; i < 10; i++) {
            yield return i;
            try {
                await Task.Delay(1000, cancellationToken);
            } catch (TaskCanceledException) {
                yield break;
            }
        }
    }
