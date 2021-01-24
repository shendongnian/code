    public static class Line {
        public struct LineSegment {
            public LineSegment(int start, int end) {
                if (!Environment.StackTrace.Contains("MyNamespace.Line") || !Environment.StackTrace.Contains("UnitTest")) {
                    throw new InvalidOperationException("Outside code is not allowed to call its constructor. Please construct your property in this file refering to the example.");
                }
                Start = start;
                End = end;
            }
            public readonly int Start;
            public readonly int End;
        }
       // User created LineSegment
       static public LineSegment Segment1() {
           return new LineSegment(1, 2);
       }
       static public LineSegment Segment2() {
           return new LineSegment(3, 6);
       }
    }
