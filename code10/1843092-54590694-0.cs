    // some preparations
    ...
    var itemIndex = 0L;
    while (await enumerator.MoveNextAsync(cancellationToken).ConfigureAwait(false))
    {
        ...
        Task itemActionTask = null;
        try
        {
            itemActionTask = asyncItemAction(enumerator.Current, itemIndex);
        }
        catch (Exception ex)
        {
           // some exception handling
        }
        ...
        itemIndex++;
    }
