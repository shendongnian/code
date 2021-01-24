    public class Rule :IEquatable<Rule>
        {
            public int TestId { get; set; }
            public string File { get; set; }
            public string Site { get; set; }
            public string[] Columns { get; set; }
    
            public bool Equals(Rule other)
            {
                return TestId == other.TestId &&
                       string.Equals(File, other.File) &&
                       Equals(Columns, other.Columns);
            }
        }
