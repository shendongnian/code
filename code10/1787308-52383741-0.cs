    public partial class MainWindow : Window
    {
        ....
        private readonly SynchronizationContext uiContext;
        public MainWindow()
        {
            InitializeComponent();
            //controls created on a specific thread can only be modified by that thread.
            //(99.99999%) of the time controls are created and modified on the UI thread
            //SynchronizationContext provides a way to capture and delegate work to the UI thread (it provides more functionality than this, but in your case this is what interests you)
            //We capture the UI Synchronization Context so that we can queue items for execution to the UI thread. We know this is the UI thread because we are in the constructor for our main window
            uiContext = SynchronizationContext.Current;
            ....
        }
        private void cmbNomiMacchine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOnUIThread();
        }
        ...............
        ///I Chose to write another method for clarity, feel free to rework the code anyway you like. Ideally you want to only delegate short work to the UI thread (say textbox.Text = "". This is just here to show the concept
       private void UpdateOnUIThread()
       {
           //Post is asynchronous so will give controll back immediately. If you want synchronous operation, use Send
           uiContext.Post(new SendOrPostCallback((o) => { updateLabelsContent(); }), null);
       }
       
       ..............
    }
}
