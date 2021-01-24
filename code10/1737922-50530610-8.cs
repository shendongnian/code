    using System;
    using NetTopologySuite.Geometries;
    using GeoAPI.CoordinateSystems;
    using GeoAPI.CoordinateSystems.Transformations;
    using ProjNet.CoordinateSystems;
    using ProjNet.CoordinateSystems.Transformations;
    
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
                ICoordinateSystem wgs84 = GeographicCoordinateSystem.WGS84;
    
                if (location.SRID != Convert.ToInt32(wgs84.AuthorityCode))
                    throw new Exception("Unsupported coordinate system: " + location.SRID);
    
                var coordinateSystemFactory = new CoordinateSystemFactory();
                var coordinateTransformationFactory = new CoordinateTransformationFactory();
    
                ICoordinateSystem wgs84UpNorth = coordinateSystemFactory.CreateFromWkt("PROJCS[\"WGS 84 / UPS North\",GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137,298.257223563]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.017453292519943295]],PROJECTION[\"Stereographic_North_Pole\"],PARAMETER[\"standard_parallel_1\",90],PARAMETER[\"central_meridian\",0],PARAMETER[\"scale_factor\",0.994],PARAMETER[\"false_easting\",2000000],PARAMETER[\"false_northing\",2000000],UNIT[\"Meter\",1]]");
    
                ICoordinateTransformation trans = coordinateTransformationFactory.CreateFromCoordinateSystems(wgs84, wgs84UpNorth);
    
                var result = trans.MathTransform.Transform(location.Coordinate);
    
                return new Point(result);
            }
        }
    }
