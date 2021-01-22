    struct Point { public int x, y; void Move(int dx, int dy) { x += dx; y += dy; } }
    ...
    Point[] points = getPointsArray();
    points[0].Move(10, 0) = 10;
    // points[0].x is now 10 higher.
    List<Point> points = getPointsList();
    points[0].Move(10, 0);
    // No error, but points[0].x hasn't changed.
