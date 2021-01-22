    mapControl.MapScale = mapControl.MapScale / 2; //for zooming
    ISpatialReferenceFactory srFactory = new SpatialReferenceEnvironmentClass(); //move up top later 
    IGeographicCoordinateSystem gcs = srFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCSType.esriSRGeoCS_WGS1984); //World lat / long format
    ISpatialReference sr1 = gcs;
    IPoint point = new PointClass(); 
    point.SpatialReference = gcs;
    point.PutCoords(-92.96000, 44.9227);
    point.Project(mapControl.SpatialReference);
    mapControl.CenterAt(point);
