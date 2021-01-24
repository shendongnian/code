    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Markup;
    
    namespace SmallTests2018
    {
    	[ContentProperty(Name = "MainContent")]
    	public sealed partial class UserControlWithContent : UserControl
    	{
    		public UserControlWithContent()
    		{
    			this.InitializeComponent();
    		}
    
    		public static DependencyProperty MainContentProperty =
    			DependencyProperty.Register("MainContent", typeof(object), typeof(UserControlWithContent), null);
    
    		public object MainContent
    		{
    			get => GetValue(MainContentProperty);
    			set => SetValue(MainContentProperty, value);
    		}
    	}
    }
