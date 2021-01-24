    int tempVal;
    if(ListId.All(j => int.TryParse(j, out tempVal)))
    {
    // All data2 strings are int's
    var newData = ListOfObjects.Select(a => a.Id).Intersect(ListId.Select(s => int.Parse(s));
    }
