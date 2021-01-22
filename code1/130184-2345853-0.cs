    using System;
    using Microsoft.SqlServer.Types;
    namespace MySqlGeometryTest
    {
        class ReportNearestPointTest
        {
            static void ReportNearestPoint(string wktPoint, string wktGeom)
            {
                SqlGeometry point = SqlGeometry.Parse(wktPoint);
                SqlGeometry geom = SqlGeometry.Parse(wktGeom);
                double distance = point.STDistance(geom).Value;
                SqlGeometry pointBuffer = point.STBuffer(distance);
                SqlGeometry pointResult = pointBuffer.STIntersection(geom);
                string wktResult = new string(pointResult.STAsText().Value);
                Console.WriteLine(wktResult);
            }
    
            static void Main(string[] args)
            {
                ReportNearestPoint("POINT(10 10)", "MULTIPOINT (80 70, 20 20, 200 170, 140 120)");
                ReportNearestPoint("POINT(110 200)", "LINESTRING (90 80, 160 150, 300 150, 340 150, 340 240)");
                ReportNearestPoint("POINT(0 0)", "POLYGON((10 20, 10 10, 20 10, 20 20, 10 20))");
                ReportNearestPoint("POINT(70 170)", "POLYGON ((110 230, 80 160, 20 160, 20 20, 200 20, 200 160, 140 160, 110 230))");
            }
        }
    }
