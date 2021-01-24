    static ViewModelLocator()
	{
		...
		SimpleIoc.Default.Register<MainViewModel>();
		SimpleIoc.Default.Register(() => new UCViewModel(), "1");
		SimpleIoc.Default.Register(() => new UCViewModel(), "2");
		...
	}
    public UCViewModel UCVM1
	{
		get
		{
			return ServiceLocator.Current.GetInstance<UCViewModel>("1");
		}
	}
	public UCViewModel UCVM2
	{
		get
		{
			return ServiceLocator.Current.GetInstance<UCViewModel>("2");
		}
	}
