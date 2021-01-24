    private LebensmittelViewModel vm = new LebensmittelViewModel();
    public Einkaufsliste ()
    {
        InitializeComponent ();
        BindingContext = vm;
    }
    public void OnSeachBarTextChange(object e, TextChangedEventArgs args)
    {
        vm.RefreshListView();
    }
