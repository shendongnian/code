    [DebuggerDisplay("{.}")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DebugModule : Module
    {
        public int FPS { get; set; }
        public override string ToString() { return "FPS = " + FPS; }
    }
