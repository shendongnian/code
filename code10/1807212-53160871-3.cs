    using System.Windows.Interop;
		public TestingWindowView(IntPtr handle)
		{
			InitializeComponent();
			new WindowInteropHelper(this).Owner = handle;
		}
