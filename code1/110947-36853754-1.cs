    [DebuggerDisplay("{DebugDisplay,nq}")]
    public sealed class Student {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string DebugDisplay {
            get { return string.Format("Student: {0} {1}", FirstName, LastName); }
        }
    }
