    // In the Views folder: /Views/MyWindow.xaml:
    // ...
    <ComboBox ItemsSource="{Binding MyViewModel.MyProperties, RelativeSource={RelativeSource AncestorType=Window}}"
    		 SelectedItem="{Binding MyViewModel.MyProperty  , RelativeSource={RelativeSource AncestorType=Window}}" />
    // ...
    
    
    
    // In the Views folder: /Views/MyWindow.xaml.cs:
    public partial class MyWindow : Window
    {
    	public  MyViewModelClass MyViewModel {
    		get { return _viewModel; }
    		private set { _viewModel = value;}
    	}
    	
    	public MyWindow()
    	{
    		MyViewModel.PropertyChanged += MyViewModel_PropertyChanged;
    		
    	}
    	
    	void MyViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    	{
    		if (e.PropertyName == "MyProperty")
    		{
    			// Do Work
    			// Put your logic here!
    		}
    	}
    }
    
    using System.ComponentModel;
    
    // In your ViewModel folder: /ViewModels/MyViewModelClass.cs:
    public class MyViewModelClass : INotifyPropertyChanged
    {
    	// INotifyPropertyChanged implementation:
    	private void NotifyPropertyChanged(string propertyName = "") { if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); } }
    	public event PropertyChangedEventHandler PropertyChanged;
    	
    	// Selected option:
    	private string _myProperty;
    	public  string  MyProperty {
    		get { return _myProperty; }
    		set { _myProperty = value; NotifyPropertyChanged("MyProperty"); }
    	}
    	
    	// Available options:
    	private List<string> _myProperties;
    	public  List<string>  MyProperties {
    		get { return _myProperties; }
    		set { _myProperties = value; NotifyPropertyChanged("MyProperties"); }
    	}
    	
    }
