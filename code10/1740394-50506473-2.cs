     public partial class MainPage : ContentPage
            {
        	    ObservableCollection<string> camImageCollection;
        		public static MainPage Instance;
        		
        		public MainPage()
                {
                    InitializeComponent();
                    Instance = this;
        
                    var btn = new Button
                    {
                        Text = "Snap!",
                        Command = new Command(o => ShouldTakePicture()),
                    };
                    CameraLayout.Children.Add(btn);  
        
                    camImageCollection = new ObservableCollection<string>();
                }
        		public event Action ShouldTakePicture = () => { };
        		
        		public void ShowImage(string[] filepath)
                {
                   foreach(var item in filepath)
                     camImageCollection.Add(item);
                     listItemsCam.FlowItemsSource = camImageCollection;
                }
        	}
	
