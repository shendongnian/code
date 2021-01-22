    internal static StrongName GetStrongName(Evidence evidence)
    {
        foreach (var e in evidence)
        {
            if (e is StrongName)
            {
                return (StrongName)e;
            }
        }
        throw new ArgumentException();
    }
