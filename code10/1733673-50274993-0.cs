        class jsonPosSample
    {
        public Rootobject rootobject;
        public Datafile datafile;
        public Point point;
        public M_Position m_Position;
        public class Rootobject
        {
            public Datafile dataFile { get; set; }
        }
        public class Datafile
        {
            public string date { get; set; }
            public string time { get; set; }
            public Point[] points { get; set; }
        }
        public class Point
        {
            public M_Position m_Position { get; set; }
        }
        public class M_Position
        {
            public float x { get; set; }
            public float y { get; set; }
            public float z { get; set; }
        }
    }
