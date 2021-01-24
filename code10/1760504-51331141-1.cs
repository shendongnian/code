    public class Pallet : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public Pallet()
    	{
    		BoxesOnPallet = new ObservableCollection<Box>();
    		BoxesOnPallet.CollectionChanged += BoxesOnPallet_CollectionChanged;
    
    		BoxesOnPallet.Add(new Box(3));
    		BoxesOnPallet.Add(new Box(8));
    		BoxesOnPallet.Add(new Box(5));
    		BoxesOnPallet.Add(new Box(1));
    		BoxesOnPallet.Add(new Box(0));
    	}
    
        private void BoxesOnPallet_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {    
    	    if (e.Action == NotifyCollectionChangedAction.Add)
    	   {
    		    foreach (var item in e.NewItems)
    		    {
    			    ((Box)item).PropertyChanged += Box_Changed;
    		    }
    	    }
    	    else if (e.Action == NotifyCollectionChangedAction.Remove)
    	    {
    		    foreach (var item in e.OldItems)
    		    {
    			    ((Box)item).PropertyChanged -= Box_Changed;
    		    }
    	    }
        }
    
    	void Box_Changed(object sender, PropertyChangedEventArgs e)
    	{
    		if (e.PropertyName == nameof(Box.NumberOfPiecesinBox))
    		{
    			OnPropertyChanged(nameof(BoxesOnPallet));
    		}
    	}
    
    	public ObservableCollection<Box> BoxesOnPallet { get; set; }
    
    	public int ItemTotal
    	{
    		get { return BoxesOnPallet.Sum(x => x.NumberOfPiecesinBox); }
    		set { }
    	}
    
    	private void OnPropertyChanged(string propertyName)
    	{
    		var handler = PropertyChanged;
    		if (handler != null)
    			handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
----------
    
    public class Box : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public Box(int num)
    	{
    		NumberOfPiecesinBox = num;
    	}
    
    	public int NumberOfPiecesinBox
    	{
    		get { return _numberOfPiecesinBox; }
    		set
    		{
    			_numberOfPiecesinBox = value;
    			OnPropertyChanged(nameof(NumberOfPiecesinBox));
    		}
    	}
    	public int _numberOfPiecesinBox;
    
    	private void OnPropertyChanged(string propertyName)
    	{
    		var handler = PropertyChanged;
    		if (handler != null)
    			handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
