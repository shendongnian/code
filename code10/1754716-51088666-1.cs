	public class CustomForm : Form
	{
		protected Size _scale;
		protected Size _originalSize;
		public CobblestoneForm() : base()
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
			if (this.BackgroundImage == null) base.OnPaintBackground(e);
			else
			{
				int x = (int)((this.Width - this._scale.Width) / 2);
				int y = (int)((this.Height - this._scale.Height) / 2);
				e.Graphics.DrawImage(this.BackgroundImage, new Rectangle(x, y, this._scale.Width, this._scale.Height));
			}
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			if (BackgroundImage != null)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CobblestoneForm));
			this.SuspendLayout();
			// 
			// CustomForm
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(106)))), ((int)(((byte)(93)))));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CustomForm";
			this.DoubleBuffered = true;
            this.ResizeRedraw = true;
			this.ResumeLayout(false);
		}
    }
