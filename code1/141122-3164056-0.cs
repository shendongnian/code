    public static void Collision.CollideCircles(ref Manifold manifold,
        CircleShape circle1, XForm xf1, CircleShape circle2, XForm xf2);
    public static void Collision.CollidePolygonAndCircle(ref Manifold manifold,
        PolygonShape polygon, XForm xf1, CircleShape circle, XForm xf2);
    public static void Collision.CollideEdgeAndCircle(ref Manifold manifold,
        EdgeShape edge, XForm transformA, CircleShape circle, XForm transformB);
    public static void Collision.CollidePolyAndEdge(ref Manifold manifold,
        PolygonShape polygon, XForm transformA, EdgeShape edge, XForm transformB);
    public static void Collision.CollidePolygons(ref Manifold manifold,
        PolygonShape polyA, XForm xfA, PolygonShape polyB, XForm xfB);
