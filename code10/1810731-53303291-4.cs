    public partial class MainPage : MasterDetailPage
    {
    	public MainPage()
    	{
    		InitializeComponent();
    		Detail = new NavigationPage(new HomePage());
    		IsPresented = false; //This is to hide side page after pushing new page 
    
    	}
    }
