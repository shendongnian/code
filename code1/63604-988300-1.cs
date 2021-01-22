    public static IDisposable EventScope(Action subscribe, Action unsubscribe)
    {
        subscribe();
        return new ActionDisposable(unsubscribe);
    }
