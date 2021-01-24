    void ParseEquals(BinaryExpression e)
    {
        var key = (MemberExpression) e.Left;
        object value;
        switch (e.Right)
        {
            case ConstantExpression constantExpression:
                value = constantExpression.Value;
                break;
            case MemberExpression memberExpression:
                var obj = ((ConstantExpression)memberExpression.Expression).Value;
                value = obj.GetType().GetField(memberExpression.Member.Name).GetValue(obj);
                break;
            default:
                throw new UnknownSwitchValueException(e.Right.Type);
        }
        result.Add(key.Member.Name, value);
    }
