    var newActions = db.Actions.Where(act => !oldActions.Contains(act));
    if (newActions.Any()) {
        // ... do something intelligent with the new actions ...
        oldActions = oldActions.Concat(newActions);
        // or perhaps oldActions.AddRange(newActions); if oldActions is a List<>
    }
