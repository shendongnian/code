    public MyWpfControl()
    {
         InitializeComponent();
         Loaded += (s, e) => { // only at this point the control is ready
             Window.GetWindow(this) // get the parent window
                   .Closing += (s1, e1) => Somewhere(); //disposing logic here
         };
    }
