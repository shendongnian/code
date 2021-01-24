    public sealed partial class MainPage : Page
    {
    	public ObservableCollection<LineViewModel> Lines = new ObservableCollection<LineViewModel>();
    
    	public MainPage()
    	{
    		InitializeComponent();
    
    		Lines.CollectionChanged += LinesOnCollectionChanged;
    		Lines.Add(new LineViewModel { Name = "Line1" });
    		Lines.Add(new LineViewModel { Name = "Line2" });
    	}
    
    	private void LinesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    	{
    		if (e.Action == NotifyCollectionChangedAction.Add)
    		{
    			MainGrid.Children.Add(new Line()
    			{
    				Name = (e.NewItems[0] as LineViewModel)?.Name ?? string.Empty,
    				Stroke = new SolidColorBrush(Colors.Black),
    				StrokeThickness = 12,
    				X1 = 0,
    				X2 = 10000
    			});
    		}
    	}
    }
    
    public class LineViewModel
    {
    	public string Name { get; set; }
    }
