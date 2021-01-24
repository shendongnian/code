        String str ="AT (1,1) ADDROOM RM0001";
        // Double all backslashes in the code, or prefix the quoted part with @
        Regex coords = new Regex("\\((\\d+),(\\d+)\\)");
        MatchCollection matches = coords.Matches(str);
        if (matches.Count > 0)
        {
            Int32 coord1 = Int32.Parse(matches[0].Groups[1].Value);
            Int32 coord2 = Int32.Parse(matches[0].Groups[2].Value);
            // Process the values...
        }
