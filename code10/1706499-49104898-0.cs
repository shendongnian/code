    foreach (var item in List1)
    {
        var match = List2.FirstOrDefault(x => x.RowNo == item.RowNo);
        if (match != null)
        {
            item.Value = match.Value;
        }
    }
