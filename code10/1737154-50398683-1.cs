    string[] thingNames = new string[listOfThings.Count];
    int[] thingIds = new int[listOfThings.Count];
    for (int i = 0; i < listOfThings.Count; i++)
    {
        thingNames[i] = listOfThings[i].Name;
        thingIds[i] = listOfThings[i].ID;
    }
