	Point OriginalMouseLocation;
	
	protected override void OnMouseDown(MouseEventArgs e) {
		base.OnMouseDown(e);
		if (e.Button == MouseButtons.Left)
			OriginalMouseLocation = 
               form.PointToClient(this.PointToScreen(new Point(-e.X, -e.Y)));
	}
	
	protected override void OnMouseMove(MouseEventArgs e) {
		base.OnMouseMove(e);
	
		if (e.Button == MouseButtons.Left) {
			Point newMouseLocation = this.PointToScreen(e.Location);
	
			newMouseLocation.Offset(OriginalMouseLocation);
			form.Location = newMouseLocation;
		}
	}
