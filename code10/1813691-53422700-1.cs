    public partial class MainWindow : Window
    {
    	public Practice.PracticeModel PracticeModel { get; set; } = new Practice.PracticeModel();
    
    	// ...
    
    	public OnButtonClicked(RoutedEventArgs e) 
    	{
    		var window = new Practice();
            // DataContext specifies which object the bindings are bound to
    		window.DataContext = this.PracticeModel;
    		window.Show();
    	}
    
    	public OnPoissonRadioChecked(RoutedEventArgs e) 
    	{
    		PracticeModel.Background = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "images/poisson_practice_screen.jpg"));
    	}
    
    	// likewise for other radio buttons ...
    }
