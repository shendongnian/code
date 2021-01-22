	public partial class MyControl : UserControl
	{
		public MyControl()
		{
			InitializeComponent();
		}
		public static readonly DependencyProperty ItemTemplateProperty =
			DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(MyControl), new UIPropertyMetadata(null));
		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate) GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}
	}
