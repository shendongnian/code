    private IList<IPoint> Contains(IGeometry geom, IEnumerable<IPoint> points) {
        var prepGeom = new NetTopologySuite.Geometries.Prepared.PreparedGeometryFactory().Prepare(geom);
        var res = new List<IPoint>();
        foreach(var point in points) {
            if (prepGeom.Contains(point)) res.Add(point);
        }
        return res;
    }
