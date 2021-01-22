    public static class ReverseEnumerable
    {
    	public static IEnumerable<TItem> Get<TItem>(IList<TItem> list)
    	{
    		return new ReverseEnumerable<TItem>(list);
    	}
    }
    
    public struct ReverseEnumerable<TItem> : IEnumerable<TItem>
    {
    	private readonly IList<TItem> _list;
    
    	public ReverseEnumerable(IList<TItem> list)
    	{
    		this._list = list;
    	}
    
    	public IEnumerator<TItem> GetEnumerator()
    	{
    		if (this._list == null)
    			return Enumerable.Empty<TItem>().GetEnumerator();
    
    		return new ReverseEnumator<TItem>(this._list);
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return this.GetEnumerator();
    	}
    }
    
    public struct ReverseEnumator<TItem> : IEnumerator<TItem>
    {
    	private readonly IList<TItem> _list;
    	private int _currentIndex;
    
    	public ReverseEnumator(IList<TItem> list)
    	{
    		this._currentIndex = list.Count;
    		this._list = list;
    	}
    
    	public bool MoveNext()
    	{
    		if (--this._currentIndex > -1)
    			return true;
    
    		return false;
    	}
    
    	public void Reset()
    	{
    		this._currentIndex = -1;
    	}
    
    	public void Dispose() { }
    
    	public TItem Current
    	{
    		get
    		{
    			if (this._currentIndex < 0)
    				return default(TItem);
    
    			if (this._currentIndex >= this._list.Count)
    				return default(TItem);
    
    			return this._list[this._currentIndex];
    		}
    	}
    
    	object IEnumerator.Current
    	{
    		get { return this.Current; }
    	}
    }
