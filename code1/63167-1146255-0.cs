        public CatalogItemScreen(IUnityContainer container) : base(container)
        {
            this.ViewModel = Container.Resolve<ICatalogItemViewModel>();
            this.View = Container.Resolve<CatalogItemView>();
            this.View.DataContext = this.ViewModel;
        }
