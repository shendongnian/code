    var ranges = myWorkBook.Names;
    
    int i = 1;
    while (i <= ranges.Count)
    {
        var currentName = ranges.Item(i, Type.Missing, Type.Missing);
        var refersTo = currentName.RefersTo.ToString();
        if (refersTo.Contains("REF!"))
        {
            ranges.Item(i, Type.Missing, Type.Missing).Delete();
        }
        else
        {
            i++;
        }
    }
