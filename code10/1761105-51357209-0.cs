        public class Result
        {
            public Category[] categories { get; set; }
            public Description description { get; set; }
            public string requestId { get; set; }
            public Metadata metadata { get; set; }
            public Color color { get; set; }
        }
        public class Description
        {
            public string[] tags { get; set; }
            public Caption[] captions { get; set; }
        }
        public class Caption
        {
            public string text { get; set; }
            public float confidence { get; set; }
        }
        public class Metadata
        {
            public int width { get; set; }
            public int height { get; set; }
            public string format { get; set; }
        }
        public class Color
        {
            public string dominantColorForeground { get; set; }
            public string dominantColorBackground { get; set; }
            public string[] dominantColors { get; set; }
            public string accentColor { get; set; }
            public bool isBWImg { get; set; }
        }
        public class Category
        {
            public string name { get; set; }
            public float score { get; set; }
        }
