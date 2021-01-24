    using System;
    using NetTopologySuite.Geometries;
    using OSGeo.OSR;
    using OSGeo.OGR;
    
    namespace YourNamespace
    {
        public class SomeLocation
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Point Location { get; } = new Point(40.1234, 1.4321) { SRID = 4326 };
    
            public Point LocationUpsNorth { get { return Wgs84ToWgs84UpsNorth(Location); } }
    
    
            private static NetTopologySuite.Geometries.Point Wgs84ToWgs84UpsNorth(Point location)
            {
                if (location.SRID != 4326)
                    throw new Exception("Unsupported coordinate system: " + location.SRID);
    
                OSGeo.OSR.SpatialReference wgs84Src = new OSGeo.OSR.SpatialReference("");
                wgs84Src.ImportFromProj4("+proj=longlat +datum=WGS84 +no_defs");
    
                OSGeo.OSR.SpatialReference stereoNorthPoleDest = new OSGeo.OSR.SpatialReference("");
                stereoNorthPoleDest.ImportFromProj4("+proj=stere +lat_0=90 +lat_ts=90 +lon_0=0 +k=0.994 +x_0=2000000 +y_0=2000000 +datum=WGS84 +units=m +no_defs");
    
                OSGeo.OSR.CoordinateTransformation ct = new OSGeo.OSR.CoordinateTransformation(wgs84Src, stereoNorthPoleDest);
    
                double[] point = new double[3];
                point[0] = location.X;
                point[1] = location.Y;
                point[2] = location.Z;
    
                ct.TransformPoint(point);
    
                return new Point(point[0], point[1]);
            }
        }
    }
