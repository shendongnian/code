    public class Rule {
        public string RuleName;
        public string Expected;
        public int StartPos;
    
        public bool IsMatch(string actual) => Field(actual) == Expected;
        public string Field(string actual) => actual.Substring(StartPos, Math.Min(Expected.Length, actual.Length-StartPos));
    public override string ToString() => $"{{ {RuleName}: @{StartPos}=\"{Expected}\" }}";
    }
