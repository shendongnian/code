    public class MyWindow : Window
    {
    	private TextBox txtNumber;
    	
    	public void Window_Loaded()
    	{
    		GenerateControls();
    	}
    	
    	public void GenerateControls()
    	{
    		Button btnClickMe = new Button();
    		btnClickMe.Content = "Click Me";
    		btnClickMe.Name = "btnClickMe";
    		btnClickMe.Click += new RoutedEventHandler(this.CallMeClick);
    		someStackPanel.Childern.Add(btnClickMe);
    		txtNumber = new TextBox();
    		txtNumber.Name = "txtNumber";
    		txtNumber.Text = "1776";
    		someStackPanel.Childern.Add(txtNumber);
    	}
    	
    	protected void ClickMeClick(object sender, RoutedEventArgs e)
    	{    
    		// Find the phone number    
    		string message = string.Format("The number is {0}", txtNumber.Text);        
    		MessageBox.Show(message);
    	}
    }
