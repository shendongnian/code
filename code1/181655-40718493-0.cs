    [Export]
    public class Part
    {
        [ImportingConstructor]
        public Part(ILog log)
        {
            Log = log;
        }
        public ILog Log { get; }
    }
    [Export(typeof(AnotherPart))]
    public class AnotherPart
    {
        [Import]
        public ILog Log { get; set; }
    }
