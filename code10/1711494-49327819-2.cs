    if (semiRandom) 
    {
        // This definition of areaHexes is visible only within these { }
        //   and is not the same as the one in the else block below
        Hex[] areaHexes = GetSemiRandomHexesWithinRangeOf(centerHex, range);
    } 
    else
    {
        // This definition of areaHexes is visible only within these { }
        //   and is not the same one as the one above
        Hex[] areaHexes = GetHexesWithinRangeOf(centerHex, range);
    }
