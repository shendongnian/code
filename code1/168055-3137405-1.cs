    using System.Windows;
    using System.Windows.Controls.Primitives;
    
    namespace StackOverflowTests
    {
    	/// <summary>
    	/// Interaction logic for Window1.xaml
    	/// </summary>
    	public partial class Window1 : Window
    	{
    		public Window1()
    		{
    			InitializeComponent();
    		}
    		
    		// Creating all the classes and setting the DataContext of each ToggleButton
    		private void Window1_Loaded(object sender, RoutedEventArgs e)
    		{
    			int sizeFactor = 0;
    
    			// for each ToggleButton in the StackPanel, create one instance of the ToggleButtonClass
    			// and assign it to the DataContext of the ToggleButton, so all the binding in the Style
    			// created in XAML can kick in.
    			foreach (UIElement element in theStackPanel.Children)
    			{
    				if (element is ToggleButton)
    				{
    					sizeFactor++;
    
    					ToggleButtonClass toggleButtonClass = new ToggleButtonClass()
    					{
    						ToggleButtonHeight = sizeFactor * 20,
    						ToggleButtonWidth = sizeFactor * 50,
    						ToggleButtonText = "Button " + sizeFactor
    					};
    
    					(element as ToggleButton).DataContext = toggleButtonClass;
    				}
    			}
    		}
    	}
    
    	// your toggle button class
    	public class ToggleButtonClass
    	{
    		public double ToggleButtonHeight { get; set; }
    		public double ToggleButtonWidth { get; set; }
    		public string ToggleButtonText { get; set; }
    	}
    }
