    public UserControl1()
    {
    	InitializeComponent();
    	if(!DesignerProperties.GetIsInDesignMode(this))
    		App.Current.MainWindow.Closing += window_Closing;
    }
