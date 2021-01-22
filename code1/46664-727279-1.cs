	public partial class ZoomListBox
	{
		public ZoomListBox()
		{
			this.InitializeComponent();
		}
        public double Zoom
        {
            get { return (double)GetValue(ZoomProperty); }
            set { SetValue(ZoomProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Zoom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.Register("Zoom", typeof(double), typeof(ZoomListBox), new UIPropertyMetadata(1.0));
	}
