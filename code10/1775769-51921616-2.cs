        Mediator _Mediator;
        public MainWindow1(Mediator _mediator)
        {
            InitializeComponent();
            _Mediator=_mediator;
            
        }
        //ON button click u notify like this
         private void button_click(object sender, RoutedEventArgs e)
        {
            _Mediator.Notify("ButtonVisibility",null)
        }
