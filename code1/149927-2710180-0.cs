	///<summary>A simple but extremely fast control.</summary>
	///<remarks>Believe it or not, a regular label isn't fast enough, even double-buffered.</remarks>
	class FastLabel : Control {
		public FastLabel() {
			SetStyle(ControlStyles.AllPaintingInWmPaint
				   | ControlStyles.CacheText
				   | ControlStyles.OptimizedDoubleBuffer
				   | ControlStyles.ResizeRedraw
				   | ControlStyles.UserPaint, true);
		}
		protected override void OnTextChanged(EventArgs e) { base.OnTextChanged(e); Invalidate(); }
		protected override void OnFontChanged(EventArgs e) { base.OnFontChanged(e); Invalidate(); }
		static readonly StringFormat format = new StringFormat {
			Alignment = StringAlignment.Center,
			LineAlignment = StringAlignment.Center
		};
		protected override void OnPaint(PaintEventArgs e) {
			e.Graphics.DrawString(Text, Font, SystemBrushes.ControlText, ClientRectangle, format);
		}
	}
