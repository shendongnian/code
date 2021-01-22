    [Export]
    public class SomeClass
    {
        [Import("Logging", typeof(ILogger))]
        public ILogger Log { get; set; }
        // etc.
    }
    public partial class Form1 : Form
    {
        [Import("Logging", typeof(ILogger))]
        public ILogger Log { set; get; }
        [Import]
        SomeClass _someClass { get; set; }
        // etc.
    }
