    var orderingList = new string[] {"LATE", "BED", "TEA", "LNCH", "MORN"};
    var newEnumerable = pouchList.OrderBy(x => x.ID3Val);
    for(int i = 0; i < orderingList.Length; i++)
    {
        newList = newList.ThenBy(x => x.ID4Val == orderingList[i]);
    }
    var newList = newEnumerable.ToList();
