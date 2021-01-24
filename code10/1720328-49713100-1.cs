    using Windows.UI.Xaml;
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Markup;
	namespace Controls
	{
		[ContentProperty(Name = "ScrollContent")]
		public sealed partial class Scroller : UserControl
		{
			public static readonly DependencyProperty ScrollContentProperty = DependencyProperty.Register("ScrollContent", typeof(object), typeof(object), new PropertyMetadata(new Grid()));
			public ScrollViewer ScrollViewer { get { return ScrollerControl; } }
			public object ScrollContent { get { return GetValue(ScrollContentProperty); } set { SetValue(ScrollContentProperty, value); } }
			public Scroller()
			{
				DataContext = this;
				this.InitializeComponent();
			}
		}
	}
