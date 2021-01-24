    List<string> aList = new List<string> { "Id", "PartCode", "PartName", "EquipType" };
    List<string> bList = new List<string> { "PartCode", "PartName", "PartShortName", "EquipmentType" };
    List<List<int>> matches = new List<List<int>>();
    for (int i = 0; i < aList.Count; i++)
    {
        var lst = new List<int>();
        matches.Add(lst);
        for (int j = 0; j < bList.Count; j++)
        {
            if (ShorthandCompare(aList[i], bList[j]))
            {
                lst.Add(j);
            }
        }
    }
