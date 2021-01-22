    public void Main()
    {
        var aContainer = GetData("A");
        var bContainer = GetData("B");
        var printProccessor = new PrintDataProcessor();
        aContainer.AcceptDataProcessor(printProccessor); // Will print A data
        bContainer.AcceptDataProcessor(printProccessor); // Will print B data
    }
    public IDataContainer GetData(string listType)
    {
        if (listType == "A")
            return new DataContainer<A>(new List<A>());
        if (listType == "B")
            return new DataContainer<B>(new List<B>());
        throw new InvalidOperationException();
    }
