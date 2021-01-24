    public sealed partial class MainPage : Page
    {
    	public ObservableCollection<LineViewModel> Lines = new ObservableCollection<LineViewModel>();
    
    	public MainPage()
    	{
    		InitializeComponent();
    
    		Lines.Add(new LineViewModel { Name = "Line1" });
    		Lines.Add(new LineViewModel { Name = "Line2" });
    	}
    }
    
    public class LineViewModel
    {
    	public string Name { get; set; }
    }
