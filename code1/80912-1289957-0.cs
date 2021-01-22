    using System.Windows.Forms;
    using System.ComponentModel;
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(doWork);
            worker.RunWorkerAsync(this);
        }
        void doWork(object sender, DoWorkEventArgs e)
        {
            ExampleForm f = e.Argument as ExampleForm;
            f.Hello();
        }
        
        private void Hello()
        {
            
        }
    }
