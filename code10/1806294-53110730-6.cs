    private List<Point> locations = new List<Point>();
    private void button1_MouseDown(object sender, MouseEventArgs e) {
        isMouseDown = true;
        locations.Add(new Point(button1.Location.X, button1.Location.Y)); // where locations[0] is your first point
    }
   
    
