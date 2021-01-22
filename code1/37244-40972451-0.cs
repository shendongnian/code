    /// <summary>
    /// The Client
    /// </summary>
    interface IDataContainer
    {
        void AcceptDataProcessor(IDataProcessor dataProcessor);
    }
    /// <summary>
    /// The Visitor.
    /// </summary>
    interface IDataProcessor
    {
        void WorkOn<TData>(List<TData> data);
    }
