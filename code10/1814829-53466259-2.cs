    public static Dictionary<int, Color> MapColours(List<int> numbersToSeekFor, List<Color> coloursToAssign)
    {
        var map = new Dictionary<int, Color>();
        for (int i = 0; i < numbersToSeekFor.Count; ++i)
            map[numbersToSeekFor[i]] = coloursToAssign[i];
        return map;
    }
