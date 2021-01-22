    int startingElement = 1;
    if (wantInitialMatch)
    {
    startingElement = 0;
    }
...
    for (int counter = startingElement; counter < m.Groups.Count; counter++)
    {
    // If we had just returned the MatchCollection directly, the
    // GroupNameFromNumber method would not be available to use
        groupings.Add(RE.GroupNameFromNumber(counter),
        .Groups[counter]);
    }
