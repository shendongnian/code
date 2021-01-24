    using System.Windows.Interop;
		public ViewTestingWindow(IntPtr handle)
		{
			InitializeComponent();
			new WindowInteropHelper(this).Owner = handle;
		}
