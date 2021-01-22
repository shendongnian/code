    public static bool IsOffensivePosition(PositionType pt)
    {
        return typeof(PositionType).GetField(Enum.GetName(typeof(PositionType), pt)).
            IsDefined(typeof(OffensivePositionAttribute), false);
    }
