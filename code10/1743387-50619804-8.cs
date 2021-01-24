    var result2 = new List<bool>(listOfLists.Count != 0 ? listOfLists[0].Count : 0);
    // Note the use of .Capacity here. It is listOfLists.Count != 0 ? listOfLists[0].Count : 0
    for (int col = 0; col < result2.Capacity; col++)
    {
        bool equal = true;
        for (int row = 1; row < listOfLists.Count; row++)
        {
            if (listOfLists[row][col] != listOfLists[0][col])
            {
                equal = false;
                break;
            }
        }
        result2.Add(equal);
    }
