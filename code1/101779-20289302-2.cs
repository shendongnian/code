    public class MyClass
    {
	    private string myProperty;
	    public string MyProperty
	    {
		    get { return myProperty; }
		    set
		    {
			    myProperty = value;
				OnPropertyChanged();
		    }
	    }
	    public event PropertyChangedEventHandler PropertyChanged;
	    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    var handler = PropertyChanged;
		    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	    }
    }
