    public class CovariantListWrapper<TOut, TIn> : IList<TOut> where TIn : TOut
    {
    	IList<TIn> list;
    
    	public CovariantListWrapper(IList<TIn> list)
    	{
    		this.list = list;
    	}
    
    	public int IndexOf(TOut item)
    	{
			// (not covariant but permitted)
    		return item is TIn ? list.IndexOf((TIn)item) : -1;
    	}
    
    	public TOut this[int index]
    	{
    		get { return list[index]; }
    		set { throw new InvalidOperationException(); }
    	}
    
    	public bool Contains(TOut item)
    	{
			// (not covariant but permitted)
    		return item is TIn && list.Contains((TIn)item);
    	}
    
    	public void CopyTo(TOut[] array, int arrayIndex)
    	{
    		foreach (TOut t in this)
    			array[arrayIndex++] = t;
    	}
    
    	public int Count { get { return list.Count; } }
    
    	public bool IsReadOnly { get { return true; } }
    
    	public IEnumerator<TOut> GetEnumerator()
    	{
    		foreach (TIn t in list)
    			yield return t;
    	}
    
    	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    	{
    		return GetEnumerator();
    	}
    
    	public void Insert(int index, TOut item) { throw new InvalidOperationException(); }
    	public void RemoveAt(int index) { throw new InvalidOperationException(); }
    	public void Add(TOut item) { throw new InvalidOperationException(); }
    	public void Clear() { throw new InvalidOperationException(); }
    	public bool Remove(TOut item) { throw new InvalidOperationException(); }
    }
