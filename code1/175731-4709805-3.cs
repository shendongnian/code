    public partial class MainWindow : Window  
    {  
    	/// <summary>  
    	/// Initializes a new instance of the <see cref="MainWindow"/> class.  
    	/// </summary>  
    	public MainWindow()  
    	{  
    		InitializeComponent();  
    
    		var xs = Observable
    			.FromEventPattern<MouseButtonEventHandler, MouseButtonEventArgs>(
    				h => (s, ea) => h(s, ea),
    				h => this.MouseDown += h,
    				h => this.MouseDown -= h);
    
    		_subscription = xs
    		    .ObserveOnDispatcher()
    		    .Subscribe(_ => txtClicked.Text = "Clicked");
    	}
    	
    	private IDisposable _subscription = null;
    }
