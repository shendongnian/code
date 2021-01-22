	protected override void OnPaintBackground(PaintEventArgs e)
	{
		using (Brush b = new LinearGradientBrush(ClientRectangle, Color.Red, Color.Blue, LinearGradientMode.ForwardDiagonal))
			e.Graphics.FillRectangle(b, ClientRectangle);
	}
