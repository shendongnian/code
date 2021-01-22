    public static bool Validate<T>(this T o, IList<IEval<T>> conditions)
    {
        bool result = true;
        Operator op = Operator.And;
        var conditionIter = conditions.GetEnumerator();
        while (result && conditionIter.MoveNext())
        {
            bool tempResult = conditionIter.Current.Expression(o);
            switch (op)
            {
                case Operator.And:
                    result &= tempResult;
                    break;
                case Operator.Or:
                    result |= tempResult;
                    break;
                default:
                    throw new NotImplementedException();
            }
            op = condition.Operator;
        }
        return result;
    }
