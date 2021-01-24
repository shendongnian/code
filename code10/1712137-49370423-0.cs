    public partial class MySettings
    {
	    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
	    {
	    	    Save();
		    base.OnPropertyChanged(sender, e);
	    }
    }
