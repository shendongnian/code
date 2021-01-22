    Collection<INail> IBucket.Nails
    {
        get
        {
            return new ListAdapter<Nail, INail>(nails);
        }
    }
    	// my implementation (it's incomplete)
    	public class ListAdapter<T_Src, T_Dst> : IList<T_Dst>
	{
		public ListAdapter(IList<T_Src> val)
		{
			_vals = val;
		}
		IList<T_Src> _vals;
		protected static T_Src ConvertToSrc(T_Dst val)
		{
			return (T_Src)((object)val);
		}
		protected static T_Dst ConvertToDst(T_Src val)
		{
			return (T_Dst)((object)val);
		}
		public void Add(T_Dst item)
		{
			T_Src val = ConvertToSrc(item);
			_vals.Add(val);
		}
		public void Clear()
		{
			_vals.Clear();
		}
		public bool Contains(T_Dst item)
		{
			return _vals.Contains(ConvertToSrc(item));
		}
		public void CopyTo(T_Dst[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}
		public int Count
		{
			get { return _vals.Count; }
		}
		public bool IsReadOnly
		{
			get { return _vals.IsReadOnly; }
		}
		public bool Remove(T_Dst item)
		{
			return _vals.Remove(ConvertToSrc(item));
		}
		public IEnumerator<T_Dst> GetEnumerator()
		{
			foreach (T_Src cur in _vals)
				yield return ConvertToDst(cur);
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		public override string ToString()
		{
			return string.Format("Count = {0}", _vals.Count);
		}
		public int IndexOf(T_Dst item)
		{
			return _vals.IndexOf(ConvertToSrc(item));
		}
		public void Insert(int index, T_Dst item)
		{
			throw new NotImplementedException();
		}
		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}
		public T_Dst this[int index]
		{
			get { return ConvertToDst(_vals[index]); }
			set { _vals[index] = ConvertToSrc(value); }
		}
	}
