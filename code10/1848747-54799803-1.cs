    public static void Swap<T>(ref this T op1, in T op2)
        where T : struct
    {
        var temp = op1;
        op1 = op2;
        RefUnlocker.Unlock(op2) = temp;
    }
