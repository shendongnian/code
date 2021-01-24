    private ResourceCollection _Resource;
    public ResourceCollection Resource
    {
        get
        {
            return _Resource;
        }
        set
        {
		    if(_Resource != null)
			{
			    _Resource.PropertyChanged -= ResourcePropertyChanged;
			}
						
            _Resource = value;
			
            if(_Resource != null)
			{
			    _Resource.PropertyChanged += ResourcePropertyChanged;
			}
						
            NotifyOfPropertyChange(() => Resource);
            NotifyOfPropertyChange(() => CanSave);
        }
    }
		
	private void ResourcePropertyChanged(object sender, EventArgs e)
	{
        //you might be able to do something better than just notify of changes here
        NotifyOfPropertyChange(() => Resource);
	    NotifyOfPropertyChange(() => CanSave);
	}
