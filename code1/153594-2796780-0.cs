    public partial class Form1 : Form
    {
        private BackgroundWorker _worker;
        public Form1()
        {
            InitializeComponent();
            _worker = new BackgroundWorker();
            _worker.DoWork += (sender, e) =>
            {
                // do some work here and calculate a result
                e.Result = "This is the result of the calculation";
            };
            _worker.RunWorkerCompleted += (sender, e) =>
            {
                // the background work completed, we may no 
                // present the result to the GUI if no exception
                // was thrown in the DoWork method
                if (e.Error != null)
                {
                    label1.Text = (string)e.Result;
                }
            };
            _worker.RunWorkerAsync();
        }
    }
