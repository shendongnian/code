    ToursDetailViewModel viewModel;
    public ToursDetail(Location location)
    {
        if (location == null)
            throw new ArgumentNullException();
       
        BindingContext = this.viewModel = new ToursDetailViewModel(location);
