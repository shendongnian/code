        public MainWindow()
        {
            InitializeComponent();
            IDisposable subscription =
                Observable
                    .FromEventPattern<MouseButtonEventHandler, MouseButtonEventArgs>(
                        h => Button.MouseLeftButtonDown += h,
                        h => Button.MouseLeftButtonDown -= h)
                    .Select(x => Observable.Start(() => { Update(42); return 42; }))
                    .Switch()
                    .ObserveOnDispatcher()
                    .Subscribe(x =>
                    {
                        // latest result only, do some work in UI
                    });
        }
