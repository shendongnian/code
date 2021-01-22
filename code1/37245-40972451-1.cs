    class DataContainer<TData> : IDataContainer
    {
        readonly List<TData> list;
        public DataContainer(List<TData> list)
        {
            this.list = list;
        }
        public void AcceptDataProcessor(IDataProcessor dataProcessor)
        {
            dataProcessor.WorkOn(list); // Here the type is known.
        }
    }
    class PrintDataProcessor : IDataProcessor
    {
        public void WorkOn<TData>(List<TData> data)
        {
            // print typed data.
        }
    }
