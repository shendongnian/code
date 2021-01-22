    	public string Name
    	{
    		get { return _Name ?? string.Empty; }
    		set
    		{
    			_Name = value;
    			NotifyPropertyChange(MethodBase.GetCurrentMethod());
    		}
    	}
    	private void NotifyPropertyChange(MemberInfo info)
    	{
    		NotifyPropertyChange(info.Name.Replace("set_", string.Empty));
    	}
    	private void NotifyPropertyChange(string property)
    	{
    		if (PropertyChanged != null)
    			PropertyChanged(this, new PropertyChangedEventArgs(property));
    	}
