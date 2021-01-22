    var mammal = new Lion();
    var extended = mammal as IExtendedData;
    if (extended != null)
    {
        string mammalData = extended.GetMoreData<Mammal>();
        string lionData = extended.GetMoreData<Lion>();
    }
