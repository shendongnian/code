	public class CustomForm : Form
	{
		protected Size _scale;
		protected Size _originalSize;
		public CustomForm() : base()
		{
			this.InitializeComponent();
		}
		protected override void OnBackgroundImageChanged(EventArgs e)
		{
			this._originalSize = new Size(this.BackgroundImage.Width, this.BackgroundImage.Height);
			base.OnBackgroundImageChanged(e);
		}
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			if ((BackgroundImage != null) && (BackgroundImageLayout == ImageLayout.None))
			{
				Point p = new Point(
                                (int)((this.Width - this._scale.Width) / 2),
                                (int)((this.Height - this._scale.Height) / 2)
                              );
				e.Graphics.DrawImage(this.BackgroundImage, new Rectangle(p, this._scale));
			}
			else
                base.OnPaintBackground(e);
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			if ((BackgroundImage != null) && (BackgroundImageLayout == ImageLayout.None))
			{
				float rX = (float) this.Width / this._originalSize.Width;
				float rY = (float) this.Height / this._originalSize.Height;
				float r = (rX < rY) ? rY : rX;
				this._scale.Height = (int)(this._originalSize.Height * r);
				this._scale.Width = (int)(this._originalSize.Width * r);
			}
			base.OnSizeChanged(e);
        }
		private void InitializeComponent()
		{
			this._originalSize = new Size(0, 0);
			this._scale = new Size(0, 0);
			this.SuspendLayout();
			// 
			// CustomForm
			// 
			this.Name = "CustomForm";
			this.DoubleBuffered = true; // minimizes "flicker" when resizing
            this.ResizeRedraw = true; // forces a full redraw when resized!
			this.ResumeLayout(false);
		}
    }
