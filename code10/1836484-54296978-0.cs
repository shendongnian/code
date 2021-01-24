	public class MainViewModel : ViewModelBase
	{
		public MyChildViewModel[] MyItems { get; } =
		{
			new MyChildViewModel{MyCustomText = "Tom" },
			new MyChildViewModel{MyCustomText = "Dick" },
			new MyChildViewModel{MyCustomText = "Harry" }
		};
	}
	public class MyChildViewModel
	{
		public string MyCustomText { get; set; }
	}
