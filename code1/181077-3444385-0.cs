    private object example(OperationType optype, Object obj, String match)
    {
       var q;
       switch (optype)
            {
            case OperationType.Contains:
                q = obj.Where(o => o.message.Contains(match));
            break;
            case OperationType.EndsWith:
                q = obj.Where(o => o.message.EndsWith(match));
            break;
            case OperationType.StartsWith:
                q = obj.Where(o => o.message.StartsWith(match));
            break;
        }
        return q;
    }
