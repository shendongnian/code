    public Command<IProduct> ViewDetailsCommand;
    public ViewModel()
    {
         ViewDetailsCommand = new Command<IProduct>(async s => await ViewDetails(s));
    }
    public IProduct SelectedProduct
    {
        get { return _selectedProduct; }
        set
        {
            if (value != _selectedProduct)
            {
                SetProperty(ref _selectedProduct, value);
                if (value != null)
                {
                    ViewDetailsCommand.Execute(value);
                }
            }
        }
    }
    
    private async Task ViewDetails(IProduct product)
    {
        var viewModel = AppContainer.Container.Resolve<ProductDetailsViewModel>();
        viewModel.Initialise(this, product as ShoppingListItemViewModel);
        SelectedProduct = null;
        await _pageNavigator.PushModalAsync(viewModel);
    }
	
