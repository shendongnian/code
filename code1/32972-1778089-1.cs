    private BlockingCollection<int> m_data = new BlockingCollection<int>();
    
    public IEnumerable<int> GetData()
    {
        Task.Factory.StartNew( ParallelGetData );
        return m_data.GetConsumingEnumerable();
    }
    private void ParallelGetData()
    {
        Parallel.ForEach( SomeDataSource(), item =>
        {
            m_data.Add( item );
        } );
        //Adding complete, the enumeration can stop now
        m_data.CompleteAdding();
    }
