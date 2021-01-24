    foreach (var item in list)
    {
        switch (Type.GetTypeCode(item.PropType))
        {
            case TypeCode.String:
                break;
            case TypeCode.Int32:
                break;
            case TypeCode.Boolean:
                break;
            default:
                throw new NotSupportedException();
        }
    }
