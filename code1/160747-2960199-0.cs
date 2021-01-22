    public class ControlVisualizerObjectSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var writer = new StreamWriter(outgoingData);
            writer.WriteLine(((Control)target).Text);
            writer.Flush();
        }
    }
    public class ControlVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(
            IDialogVisualizerService windowService,
            IVisualizerObjectProvider objectProvider)
        {
            string text = new StreamReader(objectProvider.GetData()).ReadLine();
        }
        public static void TestShowVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(ControlVisualizer),
                typeof(ControlVisualizerObjectSource));
            visualizerHost.ShowVisualizer();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ControlVisualizer.TestShowVisualizer(new Control("Hello World!"));
        }
    }
