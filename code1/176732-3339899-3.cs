    var mammal = getLion(); // Returns a lion...possibly an ExtendedLion, but possibly not
    var extended = mammal as IExtendedData;
    if (extended != null)
    {
        string mammalData = extended.GetMoreData<Mammal>();
        string lionData = extended.GetMoreData<Lion>();
    }
