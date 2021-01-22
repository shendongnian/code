	/// <summary>
	/// Inherits from PictureBox; adds Interpolation Mode Setting
	/// </summary>
	public class ClassPictureBoxIMS : PictureBox
	{
		private InterpolationMode _interpolationMode;
		public InterpolationMode UseInterpolationMode
		{
			get { return _interpolationMode; }
			set { _interpolationMode = value; }
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			pe.Graphics.InterpolationMode = _interpolationMode;
			base.OnPaint(pe);
		}
	}
