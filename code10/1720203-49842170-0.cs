    using GMap.NET;
    using GMap.NET.WindowsForms.Markers;
    
    public class Form1
    {
    
    	private GMap.NET.WindowsForms.GMapOverlay gMapOverlay;
    	private Random rand = new Random();
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    
    		GMapControl1.DragButton = MouseButtons.Left;
    		GMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
    		GMapControl1.Position = new PointLatLng(25.037531, 121.5639969);
    		GMapControl1.MinZoom = 5;
    		GMapControl1.MaxZoom = 20;
    		GMapControl1.ShowCenter = false;
    		GMapControl1.Zoom = 11;
    
    		gMapOverlay = new WindowsForms.GMapOverlay("markers");
    		gMapOverlay.IsVisibile = true;
    
    	}
    
    	private void button2_Click(object sender, EventArgs e)
    	{
    
    		var marker = new GMarkerGoogle(new PointLatLng(GetRandomDouble(24.8, 25.1), GetRandomDouble(121.3, 121.6)), GMarkerGoogleType.green);
    		var marker1 = new GMarkerGoogle(new PointLatLng(GetRandomDouble(24.8, 25.1), GetRandomDouble(121.3, 121.6)), GMarkerGoogleType.pink);
    		var marker2 = new GMarkerGoogle(new PointLatLng(GetRandomDouble(24.8, 25.1), GetRandomDouble(121.3, 121.6)), GMarkerGoogleType.blue);
    		var marker3 = new GMarkerGoogle(new PointLatLng(GetRandomDouble(24.8, 25.1), GetRandomDouble(121.3, 121.6)), GMarkerGoogleType.yellow);
    
    		marker.IsVisible = true;
    		marker1.IsVisible = true;
    		marker2.IsVisible = true;
    		marker3.IsVisible = true;
    
    		//   Clear old markers
    		gMapOverlay.Markers.Clear();
    
    		gMapOverlay.Markers.Add(marker);
    		gMapOverlay.Markers.Add(marker1);
    		gMapOverlay.Markers.Add(marker2);
    		gMapOverlay.Markers.Add(marker3);
    
    		//   Clear old overlay
    		GMapControl1.Overlays.Clear();
    		GMapControl1.Overlays.Add(gMapOverlay);
    
    		//   Zoom the map to show all drawn markers
    		GMapControl1.ZoomAndCenterMarkers(gMapOverlay.Id);
    	}
    
    	public double GetRandomDouble(double min, double max)
    	{
    		return rand.NextDouble() * (max - min) + min;
    	}
