    public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		Size mDeferredSize;
		protected override void OnHandleCreated(EventArgs e)
		{
			// Capture the "real" size...
			mDeferredSize = Size;
			// and set it to nothing...
			Size = new Size(0, 0);
			DoSomeUglyInitialization(showOptionalSplash: true);
			Size = mDeferredSize; // ...and now put it back to the original size	
			base.OnHandleCreated(e);
		}
		private void DoSomeUglyInitialization(bool showOptionalSplash)
		{
			MySplash splash = null;	
			if (showOptionalSplash)
			{
				// We have made some borderless form class with a logo or something...
				splash = new MySplash(); 
				splash.Show();
			}
			// vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
			// Initialization that REQUIRES A HANDLE, e,g,
			// we might be creating a bunch of controls, or 
			// populating a big DataGridView. Whatever it is,
			// we don't want everyone looking at our biz.
			System.Threading.Thread.Sleep(2500); // (Here simulated...)
			// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
			splash?.Dispose();		
		}
	}
