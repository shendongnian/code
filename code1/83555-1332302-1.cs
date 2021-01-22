    List<INail> tempNails = new List<INail>();
    foreach (Nail nail in nails)
    {
        tempNails.Add(nail);
    }
    ReadOnlyCollection<INail> readOnlyTempNails = new ReadOnlyCollection<INail>(tempNails);
    return readOnlyTempNails;
