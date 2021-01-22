		private Size _normalSize;
		private Point _location;
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			this.LocationChanged += new EventHandler(Form1_LocationChanged);
			this.SizeChanged += new EventHandler(Form1_SizeChanged);
		}
		void Form1_SizeChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				this._normalSize = this.Size;
			}
		}
		void Form1_LocationChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				this._location = this.Location;
			}
		}
