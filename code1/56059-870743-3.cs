    using System.Windows;
    
    namespace StackOverflowTests
    {
    	/// <summary>
    	/// Interaction logic for Window1.xaml
    	/// </summary>
    	public partial class Window1 : Window
    	{
    		public bool IsCheckBoxChecked
    		{
    			get { return (bool)GetValue(IsCheckBoxCheckedProperty); }
    			set { SetValue(IsCheckBoxCheckedProperty, value); }
    		}
    
    		// Using a DependencyProperty as the backing store for IsCheckBoxChecked.  This enables animation, styling, binding, etc...
    		public static readonly DependencyProperty IsCheckBoxCheckedProperty =
    			DependencyProperty.Register("IsCheckBoxChecked", typeof(bool), typeof(Window1), new UIPropertyMetadata(false));
    
    		public Window1()
    		{
    			InitializeComponent();
    		}
    	}
    }
