    	double panFactor = 0.025;
	
	private void btnPanNorth_Click(object sender, EventArgs e)
	{
		//   Pan North
		GMapControl1.Position = new PointLatLng(GMapControl1.Position.Lat + panFactor, GMapControl1.Position.Lng);
	}
	private void btnPanEast_Click(object sender, EventArgs e)
	{
		//   Pan East
		GMapControl1.Position = new PointLatLng(GMapControl1.Position.Lat, GMapControl1.Position.Lng + panFactor);
	}
	private void btnPanSouth_Click(object sender, EventArgs e)
	{
		//   Pan South
		GMapControl1.Position = new PointLatLng(GMapControl1.Position.Lat - panFactor, GMapControl1.Position.Lng);
	}
	private void btnPanWest_Click(object sender, EventArgs e)
	{
		//   Pan West
		GMapControl1.Position = new PointLatLng(GMapControl1.Position.Lat, GMapControl1.Position.Lng - panFactor);
	}
