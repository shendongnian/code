    Dictionary<string, ScheduledAction> oldActions = new ...;
    [...]
    var allActions = db.Actions.ToList();
    var changedActions = allActions.Where(act => !oldActions.ContainsKey(act.Id) || oldActions[act.Id].LastChanged < act.LastChanged).ToList();
    if (changedActions.Any())
    {
        // do something intelligent here
    }
