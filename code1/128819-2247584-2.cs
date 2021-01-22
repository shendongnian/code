    public class TheClass : INotifyPropertyChanged {
    	private int _property1;
    	private string _property2;
    	private double _property3;
    
    	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) {
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if(handler != null) {
    			handler(this, e);
    		}
    	}
    
    	protected void SetPropertyField<T>(string propertyName, ref T field, T newValue) {
    		if(!EqualityComparer<T>.Default.Equals(field, newValue)) {
    			field = newValue;
    			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    		}
    	}
    
    	public int Property1 {
    		get { return _property1; }
    		set { SetPropertyField("Property1", ref _property1, value); }
    	}
    	public string Property2 {
    		get { return _property2; }
    		set { SetPropertyField("Property2", ref _property2, value); }
    	}
    	public double Property3 {
    		get { return _property3; }
    		set { SetPropertyField("Property3", ref _property3, value); }
    	}
    
    	#region INotifyPropertyChanged Members
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	#endregion
    }
