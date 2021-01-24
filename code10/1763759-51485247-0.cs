    internal static IGeometry Polygonize(IGeometry geometry)
            {
                var lines = LineStringExtracter.GetLines(geometry);
                var polygonizer = new Polygonizer();
                polygonizer.Add(lines);
                var polys = polygonizer.GetPolygons();
                var polyArray = GeometryFactory.ToGeometryArray(polys);
                return geometry.Factory.CreateGeometryCollection(polyArray);
            }
    
            internal static IGeometry PolygonizeForClip(IGeometry geometry, IPreparedGeometry clip)
            {
                var lines = LineStringExtracter.GetLines(geometry);
                var clippedLines = new List<IGeometry>();
                foreach (ILineString line in lines)
                {
                    if (clip.Contains(line))
                        clippedLines.Add(line);
                }
                var polygonizer = new Polygonizer();
                polygonizer.Add(clippedLines);
                var polys = polygonizer.GetPolygons();
                var polyArray = GeometryFactory.ToGeometryArray(polys);
                return geometry.Factory.CreateGeometryCollection(polyArray);
            }
    
            internal static IGeometry SplitPolygon(IGeometry polygon, IGeometry line)
            {
                var nodedLinework = polygon.Boundary.Union(line);
                var polygons = Polygonize(nodedLinework);
    
                // only keep polygons which are inside the input
                var output = new List<IGeometry>();
                for (var i = 0; i < polygons.NumGeometries; i++)
                {
                    var candpoly = (IPolygon)polygons.GetGeometryN(i);
                    if (polygon.Contains(candpoly.InteriorPoint))
                        output.Add(candpoly);
                }
    
                return polygon.Factory.BuildGeometry(output);
            }
    
            internal static IGeometry ClipPolygon(IGeometry polygon, IPolygonal clipPolygonal)
            {
                var clipPolygon = (IGeometry)clipPolygonal;
                var nodedLinework = polygon.Boundary.Union(clipPolygon.Boundary);
                var polygons = Polygonize(nodedLinework);
    
    
                // only keep polygons which are inside the input
                var output = new List<IGeometry>();
                for (var i = 0; i < polygons.NumGeometries; i++)
                {
                    var candpoly = (IPolygon)polygons.GetGeometryN(i);
                    var interiorPoint = candpoly.InteriorPoint;
                    if (polygon.Contains(interiorPoint) &&
    
                        clipPolygon.Contains(interiorPoint))
                        output.Add(candpoly);
                }
    
                return polygon.Factory.BuildGeometry(output);
            }
