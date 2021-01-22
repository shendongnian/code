        public class ControlElement{}
        public class ControlRow
        {
            public Dictionary<string, ControlElement> Elements
            {
                get;
                set;
            }
        }
        public class Control
        {
            public List<ControlRow> Rows
            {
                get;
                set;
            }
        }
