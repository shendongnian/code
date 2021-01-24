    // create the 4 verteses
    var verteses = new List<Point3D>()
    {
        new Point3D(0, 0, 0),
        new Point3D(10, 0, 0),
        new Point3D(10, 10, 0),
        new Point3D(0, 10, 0)
    }
    
    // create the region on the XY plane using the static method
    var region = CreateRegion(verteses);
    // extrude the region in Z by 10 units
    var solid = CreateSolidFromRegion(region, 10d);
