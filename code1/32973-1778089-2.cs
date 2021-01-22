    private BlockingCollection<T> m_data = new BlockingCollection<T>();
    
    public IEnumerable<T> GetData( IEnumerable<IEnumerable<T>> sources )
    {
        Task.Factory.StartNew( () => ParallelGetData( sources ) );
        return m_data.GetConsumingEnumerable();
    }
    private void ParallelGetData( IEnumerable<IEnumerable<T>> sources )
    {
        foreach( var source in sources )
        {
            foreach( var item in source )
            {
                m_data.Add( item );
            };
        }
        //Adding complete, the enumeration can stop now
        m_data.CompleteAdding();
    }
