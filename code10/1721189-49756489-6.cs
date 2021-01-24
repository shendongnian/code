    public View()
    {
    	InitializeComponent();
    
    	if (!DesignerProperties.GetIsInDesignMode(this))
    	{
    		this.IsVisibleChanged += (o, e) =>
    		{
    			if (this.IsVisible)
    				(this.DataContext as ViewModel).Refresh();
    		};
    	}
    }
