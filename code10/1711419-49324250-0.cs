    private MvxCommand<FooModel> _timeClickedCommand;
	public IMvxCommand TimeClickedCommand
	{
		get
		{
            _timeClickedCommand = _timeClickedCommand ?? new MvxCommand<FooModel>(Mvx.Resolve<IMvxNavigationService>().Navigate(new FooViewModel()));
		    return _timeClickedCommand;
		}
	}
