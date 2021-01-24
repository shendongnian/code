	public class MyPage : ContentPage // (assuming the page is called "MyPage" and is of type ContentPage)
	{
		MyViewModel _viewModel;
		
		public MyPage()
		{
			InitializeComponent();
			_viewModel = new MyViewModel();
			BindingContext = _viewModel;
            // bind the view model's List property to the list view's ItemsSource:
            mainList.setBinding(ListView.ItemsSourceProperty, "List");
		}
	}
