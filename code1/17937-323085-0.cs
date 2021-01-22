    public class UsefulBindingList<T> : BindingList<T>
    {
    	private bool _isSorted = false;
    	private ListSortDirection _sortDirection;
    	private PropertyDescriptor _sortProperty;
    
    	protected override bool SupportsSortingCore
    	{
    		get { return true; }
    	}
    
    	protected override bool IsSortedCore
    	{
    		get { return _isSorted; }
    	}
    
    	protected override ListSortDirection SortDirectionCore
    	{
    		get { return _sortDirection; }
    	}
    
    	protected override PropertyDescriptor SortPropertyCore
    	{
    		get { return _sortProperty; }
    	}
    	
    	
    	public void AddRange(IEnumerable<T> collection)
    	{
    		IEnumerator<T> e = collection.GetEnumerator();
    		while (e.MoveNext())
    		{
    			this.Add(e.Current);
    		}
    	}
    
    	public T Find(Predicate<T> match)
    	{
    		List<T> items = this.Items as List<T>;
    		if (items != null)
    			return items.Find(match);
    		else
    			return default(T);
    	}
    
    	public int FindIndex(Predicate<T> match)
    	{
    		List<T> items = this.Items as List<T>;
    		if (items != null)
    			return items.FindIndex(match);
    		else
    			return -1;
    	}
    
    	public bool Exists(Predicate<T> match)
    	{
    		List<T> items = this.Items as List<T>;
    		return items.Exists(match);
    	}
    
    	public void Sort()
    	{
    		List<T> items = this.Items as List<T>;
    		if (items != null)
    			items.Sort();
    	}
    
    	public void Sort(Comparison<T> comparison)
    	{
    		List<T> items = this.Items as List<T>;
    		if (items != null)
    			items.Sort(comparison);
    	}
    
    	public void Sort(IComparer<T> comparer)
    	{
    		List<T> items = this.Items as List<T>;
    		if (items != null)
    			items.Sort(comparer);
    	}
    
    	protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    	{
    		_sortProperty = prop;
    		_sortDirection = direction;
    
    		List<T> items = this.Items as List<T>;
    		if (items != null)
    		{
    			PropertyComparer<T> pc = new PropertyComparer<T>(prop, direction);
    			items.Sort(pc);
    			_isSorted = true;
    		}
    		else
    		{
    			_isSorted = false;
    		}
    		this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    	}
    
    	protected override void RemoveSortCore()
    	{
    		_isSorted = false;
    	}
    
    }
    
    public class PropertyComparer<T> : IComparer<T>
    {
    	private ListSortDirection _sortDirection;
    	private PropertyDescriptor _property;
    
    	public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
    	{
    		_property = property;
    		_sortDirection = direction;
    	}
    
    	public int Compare(T x, T y)
    	{
    		int rv = 0;
    		object vx = _property.GetValue(x);
    		object vy = _property.GetValue(y);
    		rv = System.Collections.Comparer.Default.Compare(vx, vy);
    		if (_sortDirection == ListSortDirection.Descending)
    			rv = -rv;
    		return rv;
    	}
    
    }
