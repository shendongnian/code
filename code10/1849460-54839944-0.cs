    public class MainViewModel : ViewModelBase
    {
    	public StudentViewModel StudentViewModel { get; set; }
    
    	public MainViewModel()
    	{
    		StudentViewModel = new StudentViewModel();
    	}
    }
