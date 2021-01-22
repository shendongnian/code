    // ******************************************************************
    public DlgAddAggregateCalc()
    {
        InitializeComponent();
        Model = DataContext as DlgAddAggregateCalcViewModel;
		this.Activated += OnActivated;
		this.Deactivated += OnDeactivated;
	}
	// ************************************************************************
	private void OnDeactivated(object sender, EventArgs eventArgs)
	{
		Global.Instance.PullState();
	}
	// ************************************************************************
	private void OnActivated(object sender, EventArgs eventArgs)
	{
		Global.Instance.PushState(false);
	}
