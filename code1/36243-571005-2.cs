    public class TvShowsDataSource
    {
    	public ObservableCollection<Show> Shows { get; set; }
    	
    	private void AddItems(IEnumerable<Show> shows)
    	{
                foreach(var show in shows)
                       Shows.Add(show);
    	}
    	
    	public void LoadShowsAsync(Dispatcher dispatcher)
    	{
                ThreadPool.QueueUserWorkItem((state) =>
                       LoadShows(dispatcher));
    	}
    	
    	private void LoadShows(Dispatcher dispatcher)
    	{
    		if (dispatcher == null)
    			throw new ArgumentNullException("dispatcher");
    	
    		using (var context = new Data.TVShowDataContext())
    		{
    		    var list = from show in context.Shows
    		               select show;
    		
    		    dispatcher.Invoke(AddItems(list));
    		}
    	}
    }
    
    public class UserControl1
    {
    	private readonly TvShowsDataSource tvShowsDataSource;
    	public UserControl1() : this(new TvShowsDataSource()) {}
    	
    	public UserControl1(TvShowsDataSource tvShowsDataSource )
    	{
    		InitializeComponent();
    		this.tvShowsDataSource = tvShowsDataSource;
    		listShow.ItemsSource = tvShowsDataSource.Shows;
    		this.Loaded += UserControl1_Loaded;
    	}
    	
    	public void UserControl1_Loaded(object sender, RoutedEventArgs e)
    	{
    		if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
    		{
    			tvShowsDataSource.LoadShowsAsync(this.Dispatcher);
    		}
    	}
    }
