		public MainWindow()
		{
			InitializeComponent();
			CompositionTarget.Rendering += CompositionTarget_Rendering;
		}		
		private void CompositionTarget_Rendering(object sender, EventArgs e)
		{
			// remove reference to old image
			this.theImage.Source = null;
			// invoke GC
			Debug.WriteLine(GC.GetTotalMemory(false));
			GC.Collect();
			Debug.WriteLine(GC.GetTotalMemory(false));
			// create and assign new image
			const int width = 1000;
			const int height = 1000;
			var pixels = new uint[width * height];
			uint color = (uint)((new Random((int)DateTime.Now.Ticks)).Next(0x1000000) | 0xff000000);
			for (int i = 0; i < width * height; i++)
				pixels[i] = color;
			this.theImage.Source = BitmapSource.Create(width, height, 96, 96, PixelFormats.Bgra32, null, pixels, width * 4);
		}
