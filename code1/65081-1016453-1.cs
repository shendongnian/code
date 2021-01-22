    namespace WPFCommandTarget
    {
    	/// <summary>
    	/// Interaction logic for CustomToolBar.xaml
    	/// </summary>
    	public partial class CustomToolBar : UserControl
    	{
    		public CustomToolBar()
    		{
    			InitializeComponent();
    		}
    
    		public IInputElement CommandTarget
    		{
    			get { return (IInputElement)GetValue(CommandTargetProperty); }
    			set { SetValue(CommandTargetProperty, value); }
    		}
    
    		// Using a DependencyProperty as the backing store for CommandTarget.  This enables animation, styling, binding, etc...
    		public static readonly DependencyProperty CommandTargetProperty =
    			DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(CustomToolBar), new UIPropertyMetadata(null));
    	}
    }
