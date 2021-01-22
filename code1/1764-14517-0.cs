    [Flags]
    public enum PESHeaderFlags
    {
        IsCopy = 1, // implied that if not present, then it is an original
        IsCopyrighted = 2,
        IsDataAligned = 4,
        Priority = 8,
        ScramblingControlType1 = 0,
        ScramblingControlType2 = 16,
        ScramblingControlType3 = 32,
        ScramblingControlType4 = 16+32,
        ScramblingControlFlags = ScramblingControlType1 | ScramblingControlType2 | ... ype4
        etc.
    }
