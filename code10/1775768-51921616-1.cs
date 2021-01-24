        Mediator _Mediator
        public MainWindow()
        {
            InitializeComponent();
            _Mediator= Mediator.Instance;
             _Mediator.Register("ButtonVisibility",ChangeButtonVisibility);
            
        }
        private void ChangeButtonVibility(object obj)
        {
          this.button.Visibility=Visibility.Hidden;
        }
