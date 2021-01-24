    public MyViewModel()
    {
        var itemChangedObs = this.WhenAnyValue(x => x.MyObject.Active);
        var isBusyObs = this.WhenAnyValue(x => x.IsBusy);
        // Recalculate the # of active objects each time ObjectList is reassigned.
        var activeListItemCountInitializedObs = this
            .WhenAnyValue(x => x.ObjectList)
            .Select(
                list =>
                {
                    // Return 0 if ObjectList is null.
                    return list == null ? Observable.Return(0) : list
                        .ToObservable()
                        // Otherwise, increment by 1 for each active object.
                        .Select(x => x.Active ? 1 : 0)
                        // We use Aggregate, which is a single value sequence, because
                        // we're only interested in the final result.
                        .Aggregate((acc, current) => acc + current);
                })
            // We no longer need the inner observable from the last time active item count
            // was initialized. So unsubscribe from that one and subscribe to this most recent one.
            .Switch();
        var activeListItemCountChangedObs = this
            .WhenAnyObservable(x => x.ObjectList.ItemChanged)
            .Where(x => x.PropertyName == "Active")
            // Increment or decrement the number of active objects in the list.
            .Select(x => x.Sender.Active ? 1 : -1);
        // An IObservable<bool> that signals if *any* of objects in the list are active.
        var anyListItemsActiveObs = activeListItemCountInitializedObs
            .Select(
                // Use the initialized count as the starting value for the Scan accumulator.
                initialActiveCount =>
                {
                    return activeListItemCountChangedObs
                        .Scan(initialActiveCount, (acc, current) => acc + current)
                        // Return true if one or more items are active.
                        .Select(x => x > 0)
                        .StartWith(initialActiveCount > 0);
                })
            // ObjectList was completely reassigned, so the previous Scan accumulator is
            // no longer valid. So we "reset" it by "switching" to the new one.
            .Switch();
        var canRunCommand = itemChangedObs
            .CombineLatest(
                anyListItemsActiveObs,
                isBusyObs,
                (itemActive, listItemActive, isBusy) => (itemActive || listItemActive) && !isBusy);
        Save = ReactiveCommand.CreateFromObservable(() => Observable.Return(Unit.Default), canRunCommand);
    }
