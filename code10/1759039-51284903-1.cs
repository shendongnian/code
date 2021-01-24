    public class ViewModel
    {
    	public IEnumerable Items { get; set; }
    	public IEnumerable SelectedItems { get; set; }
    
    	public ViewModel()
    	{
    		Items = new List<string> { "Test", "Test1" };
    		SelectedItems = new List<string> { "Test" };
    	}
    }
