    public class ObservableStack<T> : Stack<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
    	public ObservableStack()
    	{
    	}
    
    	public ObservableStack(IEnumerable<T> collection)
    	{
    		foreach (var item in collection)
    			base.Push(item);
    	}
    
    	public ObservableStack(List<T> list)
    	{
    		foreach (var item in list)
    			base.Push(item);
    	}
    
    
    	public new virtual void Clear()
    	{
    		base.Clear();
    		this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    	}
    
    	public new virtual T Pop()
    	{
    		var item = base.Pop();
    		this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
    		return item;
    	}
    
    	public new virtual void Push(T item)
    	{
    		base.Push(item);
    		this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
    	}
    
    
    	public virtual event NotifyCollectionChangedEventHandler CollectionChanged;
    
    	
    	protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    	{
    		this.RaiseCollectionChanged(e);
    	}
    
    	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    	{
    		this.RaisePropertyChanged(e);
    	}
    	
    	
    	protected virtual event PropertyChangedEventHandler PropertyChanged;
    
    
    	private void RaiseCollectionChanged(NotifyCollectionChangedEventArgs e)
    	{
    		if (this.CollectionChanged != null)
    			this.CollectionChanged(this, e);
    	}
    
    	private void RaisePropertyChanged(PropertyChangedEventArgs e)
    	{
    		if (this.PropertyChanged != null)
    			this.PropertyChanged(this, e);
    	}
    
    	
    	event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
    	{
    		add { this.PropertyChanged += value; }
    		remove { this.PropertyChanged -= value; }
    	}
    }
