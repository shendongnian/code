    public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();
			ContentControl.DataContext = new SomeObject();
			
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ContentControl.Content = XamlReader.Load("<TextBlock xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Text=\"Hello\"/>");
		}
	}
	public class SomeObject
	{
		private object _contentProperty = null;
		public object ContentProperty
		{
			get
			{
				return _contentProperty;
			}
			set
			{
				_contentProperty = value;
				MessageBox.Show("Content Changed");
			}
		}
	}
