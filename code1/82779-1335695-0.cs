    public sealed class SyncronizedDictionary<TKey, TValue>
    {
    	private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
    	private readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();
    
    	public TValue this[TKey key]
    	{
    		get
    		{
    			readerWriterLock.EnterReadLock();
    			try
    			{
    				return this.dictionary[key];
    			}
    			finally
    			{
    				readerWriterLock.ExitReadLock();
    			}
    		}
    		set
    		{
    			readerWriterLock.EnterWriteLock();
    			try
    			{
    				this.dictionary[key] = value;
    			}
    			finally
    			{
    				readerWriterLock.ExitWriteLock();
    			}
    		}
    	}
    
    	public bool TryGetValue(TKey key, out TValue value)
    	{
    		readerWriterLock.EnterReadLock();
    		try
    		{
    			return this.dictionary.TryGetValue(key, out value);
    		}
    		finally
    		{
    			readerWriterLock.ExitReadLock();
    		}
    	}
    }
