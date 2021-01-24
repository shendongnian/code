    static ViewModelLocator()
    {
        ....
        SimpleIoc.Default.Register<MainViewModel>();
        SimpleIoc.Default.Register<UCViewModel>();
        ....
    }
    public UCViewModel CM
    {
        get
        {
            return ServiceLocator.Current.GetInstance<UCViewModel>();
        }
    }
