    public static class Line
    {
        private struct LineSegment : ILineSegment
        {
            public int Start { get; }
            public int End { get; }
            public LineSegment(int start, int end)
            {
                Start = start;
                End = end;
            }
        }
        // User created LineSegment
        static public ILineSegment Segment1()
        {
            return new LineSegment(1, 2);
        }
        static public ILineSegment Segment2()
        {
            return new LineSegment(3, 6);
        }
