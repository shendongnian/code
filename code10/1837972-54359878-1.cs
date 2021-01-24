    // My dummy ImageWrapper
    public class ImageWrapper
    {
        public string Val { get; set; }
    }
    public partial class MainWindow
    {
        private CallbackRestriction _restriction = new CallbackRestriction();
        public MainWindow()
        {
            InitializeComponent();
            _restriction.AddCallback(MyCallback, new ImageWrapper() {Val = "Hello"});
            Task.Run(_restriction.CallbackEmitLoop);
        }
        private void MyCallback(ImageWrapper wrapper)
        {
            // since the callback will be running on the 
            // thread associated with the task, if you
            // want to interact with the UI in the callback
            // you need to use Dispatcher
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Debug.WriteLine(wrapper.Val);
            }));
        }
    }
