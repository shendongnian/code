    public static bool TryGetIntIntAction(
        ActionType type, out Func<int, int, int> func)
    {
        switch (type)
        {
        case ActionType.Action1:
            func = (val1, val2) => new ActionClass1(val1, val2).DoAction();
            return true;
        default:
            func = null;
            return false;
        }
    }
    public static bool TryGetStringAction(
        ActionType type, out Func<string, int> func)
    {
        switch (type)
        {
        case ActionType.Action2:
            func = val1 => new ActionClass2(val1).DoAction();
            return true;
        case ActionType.Action3:
            func = val1 => new ActionClass3(val1).DoAction();
            return true;
        default:
            func = null;
            return false;
        }
    }
