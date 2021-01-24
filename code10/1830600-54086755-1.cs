    public class TestViewModel : BasePropertyChangeNotification
    {
    	public ObservableCollection<Uri> PathList
    	{
    		get;
    		private set;
    	}
    
    	public Uri SelectedImagePath
    	{
    		get { return this.selectedImagePath; }
    		set { this.SetProperty(ref this.selectedImagePath, value); }
    	}
    	private Uri selectedImagePath = new Uri("pack://application:,,,/Images/img1.jpg", UriKind.RelativeOrAbsolute);
    
    	public TestViewModel()
    	{
    		this.PathList = new ObservableCollection<Uri>
    		{
    			new Uri("pack://application:,,,/Images/img1.jpg", UriKind.RelativeOrAbsolute),
    			new Uri("pack://application:,,,/Images/img2.jpg", UriKind.RelativeOrAbsolute),
    			new Uri("pack://application:,,,/Images/img3.jpg", UriKind.RelativeOrAbsolute),
    			new Uri("pack://application:,,,/Images/img4.jpg", UriKind.RelativeOrAbsolute),
    			new Uri("pack://application:,,,/Images/img13.jpg", UriKind.RelativeOrAbsolute)
    		};
    	}
    }
