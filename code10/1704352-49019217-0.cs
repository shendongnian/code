    public class MyButton : INotifyPropertyChanged
    {
    	//Assume all properties did change notifications
    	
    	public string Text { get; set; }
    	public ICommand Command { get; set; }
    	public Visibility Visibility { get; set; }
    }
