        public class Process
        {
            public int Id
            {
                get; set;
            }
            public int ProcessId
            {
                get; set;
            }
            public int Sequence
            {
                get; set;
            }
            public List<Process> Children
            {
                get; set;
            }
        }
