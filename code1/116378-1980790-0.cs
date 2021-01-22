	///<summary>A blank control for drawing on.</summary>
	[DefaultEvent("Paint")]
	[Description("A blank control for drawing on.")]
	[ToolboxBitmap(typeof(Canvas), "Images.Canvas.png")]
	public class Canvas : Control {
		///<summary>Creates a new Canvas control.</summary>
		public Canvas() {
			SetStyle(ControlStyles.AllPaintingInWmPaint
				   | ControlStyles.UserPaint
				   | ControlStyles.Opaque
				   | ControlStyles.OptimizedDoubleBuffer
				   | ControlStyles.ResizeRedraw,
					 true);
		}
		///<summary>Gets or sets whether the control should completely repaint when it is resized.</summary>
		[Description("Gets or sets whether the control should completely repaint when it is resized.")]
		[DefaultValue(true)]
		[Category("Appearance")]
		public new bool ResizeRedraw {
			get { return base.ResizeRedraw; }
			set { base.ResizeRedraw = value; }
		}
		///<summary>Raises the Paint event.</summary>
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "CA Bug")]
		protected override void OnPaint(PaintEventArgs e) {
			if (e == null) throw new ArgumentNullException("e");
			if (ShowDesignMessage && DesignMode) {
				using (var brush = new LinearGradientBrush(ClientRectangle, Color.AliceBlue, Color.DodgerBlue, LinearGradientMode.Vertical)) {
					e.Graphics.FillRectangle(brush, ClientRectangle);
				}
				using (var font = new Font("Segoe UI", 18))
				using (var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }) {
					e.Graphics.DrawString("Canvas Control", font, Brushes.DarkBlue, ClientRectangle, format);
				}
			} else
				base.OnPaint(e);
		}
		///<summary>Gets whether to paint a message in design mode instead of firing the Paint event.</summary>
		[Browsable(false)]
		protected virtual bool ShowDesignMessage { get { return true; } }
	}
