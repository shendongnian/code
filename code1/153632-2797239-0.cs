    bool isPresent = objectStateManager.TryGetObjectStateEntry(((IEntityWithKey)order).EntityKey, out stateEntry);
    if (isPresent)
    {
        Console.WriteLine("The entity was found");
    }
