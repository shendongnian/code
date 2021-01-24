    namespace RemoveItSelf
    {
    	public partial class MainPage : ContentPage
    	{
    		public MainPage()
    		{
    			InitializeComponent();
    		}
    
    	    private void PressMeButton_Clicked(object sender, EventArgs e)
    	    {
    	        //stack.Children.RemoveAt(0);
    	        stack.Children.RemoveAt(stack.Children.Count - 1);
            }
    	}
    }
