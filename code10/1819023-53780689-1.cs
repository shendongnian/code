       public FunctionTreeView()
        {
            InitializeComponent();
            this.WhenActivated(
                dis =>
                {
                    this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext).DisposeWith(dis);
                    this.OneWayBind(ViewModel, vm => vm.ItemType_1ViewModelList , x => x.TheTreeView.ItemsSource).DisposeWith(dis);
                });
        }
