    public static Func<int, int, int> GetIntIntAction(ActionType type)
    {
        switch (type)
        {
        case ActionType.Action1:
            return (val1, val2) => new ActionClass1(val1, val2).DoAction();
        default:
            throw new NotImplementedException();
        }
    }
    public static Func<string, int> GetStringAction(ActionType type)
    {
        switch (type)
        {
        case ActionType.Action2:
            return val1 => new ActionClass2(val1).DoAction();
        case ActionType.Action3:
            return val1 => new ActionClass3(val1).DoAction();
        default:
            throw new NotImplementedException();
        }
    }
