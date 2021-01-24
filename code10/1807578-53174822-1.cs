    using Rhino.Geometry;
    using System;
    Transform xf = Transform.Translation(vec);
    id = doc.Objects.Transform(id, xf, true);
    Point pos = doc.Objects.Find(id).Geometry as Point
    Point3d pos3d = pos.Location;
