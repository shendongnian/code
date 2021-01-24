    using NetTopologySuite.Geometries;
    using NetTopologySuite.Geometries.Implementation;
    using System.Diagnostics;
    namespace NetTopologyTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                //This sequence has to be initialized with ordinates XYZM. If you construct it
                //with just XYZ values, then you can't add M values to it later.
                var coordinateSequence = new DotSpatialAffineCoordinateSequence(new[] { 1.0, 2.0 }, new[] { 3.0 }, new[] { 4.0 });
                var sequenceFactory = new DotSpatialAffineCoordinateSequenceFactory(GeoAPI.Geometries.Ordinates.XYZM);
                var geometryFactory = new GeometryFactory(sequenceFactory);
                var p3 = new Point(coordinateSequence, geometryFactory);
                p3.Y = 8;
                p3.M = 1;
                var m = p3.M;
                Debug.WriteLine(p3);
                Debug.WriteLine(p3.M);
                Debug.WriteLine(m);
            }
        }
    }
