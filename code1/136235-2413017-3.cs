	public class ClassB : System.ComponentModel.INotifyPropertyChanged
	{
	    private string myprop;
	    public string MyProp
	    {
		get
		{
		    return myprop;
		}
		set
		{
		    if (value != myprop)
		    {
			myprop = value;
			if (PropertyChanged != null)
			{
			    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("MyProp"));
			}
		    }
		}
	    }
	    #region INotifyPropertyChanged Members
	    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	    #endregion
	}
