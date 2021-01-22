		public MyForm()
		{
			InitializeComponent();
			statusStrip1.Renderer = new MyRenderer();
		}
		private class MyRenderer : ToolStripProfessionalRenderer
		{
			protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
			{
				// don't draw at all
			}
		}
