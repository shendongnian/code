    public async IAsyncEnumerable<int> EnumerateAsync(CancellationToken cancellationToken = default) {
        for (int i = 0; i < 10; i++) {
            yield return i;
            await Task.Delay(1000, cancellationToken);
        }
    }
