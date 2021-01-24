    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    
    		TileItemCollection = new ObservableCollection<TileItem>(new []
    		{
    			new TileItem(){Category = "Alpha", Hour = "10", Title = "Hello World", Where = "Office"}, 
    			new TileItem(){Category = "Beta", Hour = "15", Title = "Test", Where = "Home"}, 
    			new TileItem(){Category = "Gamma", Hour = "44", Title = "My Title", Where = "Work"}, 
    		});
    
    		DataContext = this;
    	}
    
    	public ObservableCollection<TileItem> TileItemCollection { get; }
    }
