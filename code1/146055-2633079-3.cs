    [Flags()]
	public enum Options
	{
		Plain = 0,
		Ketchup = 1,
		Mustard = 2,
		Mayo = 4,
		HotSauce = 8
	}
	public partial class DataBoundFlags : Window
	{
		public static readonly DependencyProperty SelectedOptionsProperty =
			DependencyProperty.Register("SelectedOptions", typeof(Options), typeof(DataBoundFlags));
		public Options SelectedOptions
		{
			get { return (Options)GetValue(SelectedOptionsProperty); }
			set { SetValue(SelectedOptionsProperty, value); }
		}
		public List<Options> AvailableOptions
		{
			get
			{
				return new List<Options>()
				{
					Options.Ketchup,
					Options.Mustard,
					Options.Mayo,
					Options.HotSauce
				};
			}
		}
		public ICommand SelectCommand
		{
			get;
			private set;
		}
		/// <summary>
		/// If the option is selected, unselect it.
		/// Otherwise, select it.
		/// </summary>
		private void OnSelect(Options option)
		{
			if ((SelectedOptions & option) == option)
				SelectedOptions = SelectedOptions & ~option;
			else
				SelectedOptions |= option;
		}
		public DataBoundFlags()
		{
			SelectCommand = new RelayCommand((o) => OnSelect((Options)o));
			InitializeComponent();
		}
	}
