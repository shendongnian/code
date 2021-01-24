    Hex[] areaHexes;
    if (semiRandom) 
    { 
        areaHexes = GetSemiRandomHexesWithinRangeOf(centerHex, range);
    }
    else 
    {
        areaHexes = GetHexesWithinRangeOf(centerHex, range);
    }
