    public static tEnum SetFlags<tEnum>(this Enum e, tEnum flags, bool set, bool typeCheck = true) where tEnum : IComparable
    {
        if (typeCheck)
        {
            if (e.GetType() != flags.GetType())
                throw new ArgumentException("Argument is not the same type as this instance.", "flags");
        }
        var flagsUnderlyingType = Enum.GetUnderlyingType(typeof(tEnum));
        var firstNum = Convert.ToUInt32(e);
        var secondNum = Convert.ToUInt32(flags);
        if (set)
            firstNum |= secondNum;
        else
            firstNum &= ~secondNum;
        var newValue = (tEnum)Convert.ChangeType(firstNum, flagsUnderlyingType);
        if (!typeCheck)
        {
            var values = Enum.GetValues(typeof(tEnum));
            var lastValue = (tEnum)values.GetValue(values.Length - 1);
            if (newValue.CompareTo(lastValue) > 0)
                return lastValue;
        }
        return newValue;
    }
