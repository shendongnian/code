    public abstract class Platform { public abstract string Newline { get; } }
    
    public sealed class Unix : Platform {
        public override string Newline { get { return "\n"; } }
    }
