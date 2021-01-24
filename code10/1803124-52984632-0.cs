        public static class Line {
            public struct LineSegment {
                [Obsolete("DO NOT USE THIS DIRECTLY...")]
                public LineSegment(int start, int end) {
                    Start = start;
                    End = end;
                }
        
            public readonly int Start;
            public readonly int End;
            }
        
           // User created LineSegment
           static public LineSegment Segment1() {
               return _CreateSegment(1, 2);
           }
        
           static public LineSegment Segment2() {
               return _CreateSegment(3, 6);
           }
    
           static private LineSegment _CreateSegment(int start,int end) {
    //we don't want to trigger the warning ...
    #pragma warning disable 618
               return new LineSegment(3, 6);
    #pragma warning restore 618
           }
        }
