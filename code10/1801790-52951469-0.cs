    IAsyncEnumerable<int> asyncSequence = ...
    ValueTask<bool> valueTask = asyncSequence.MoveNextAsync();
    if (valueTask.IsFaulted) {
        var ex = valueTask.AsTask().Exception;
        // work with the exception
    }
    ValueTask endTask = asyncSequence.DisposeAsync();
    if (endTask.IsFaulted) {
        var ex = valueTask.AsTask().Exception;
        // work with the exception
    }
