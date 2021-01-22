    this.Region = this.CreateNewRegion();
    // ...
    private Region CreateNewRegion() {
       var points = new Point[] { new Point(0,0), new Point(20,0), new Point(30, 50) };
       var path = new System.Drawing.Drawing2D.GraphicPath();
       path.AddPolygon( points );
       var region = new Region( path );
       return region;
    }
