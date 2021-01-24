    private MyViewModel _viewModel;
    public VehicleInOutWnd()
    {
        InitializeComponent();
    	_viewModel = new MyViewModel();
    	this.DataContext = _viewModel;
    	
    	public void ClickButton() 
    	{
    		// You could just access _viewModel.MyDataList for an up-to-date list.
    	}
    }
