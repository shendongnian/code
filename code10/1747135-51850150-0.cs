           using GeoAPI.Geometries;
           using NetTopologySuite.IO;
           using DotSpatial.Data;
           // From any WKT string
            String WKT = "MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)),((20 35, 10 30, 10 10, 30 5, 45 20, 20 35),(30 20, 20 15, 20 25, 30 20)))";
            // Create a Well Known Text Reader from NetTopologySuite
            WKTReader reader = new WKTReader();
            // NetTopologySuite passes back a GeoApi IGeometry.  This is a shared interface that can be used by both libraries.
            IGeometry geom = reader.Read(WKT);
            // Create a Feature (a DotSpatial object) using the GeoApi IGeometry from NetTopologySuite.
            Feature f = new Feature(geom);
