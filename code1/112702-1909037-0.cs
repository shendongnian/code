    public delegate void DelegateInitializeGrid(DataView tbl);
    public class MyMainClass : Strategy
    {
        RunForm runForm;
        Thread oThread;
        Thread tThread;
        public delegate void updateGridCallback(DataTable tbl);
        private DataTable tbl = new DataTable();
        public DataTable ctbl = new DataTable();
        private DataView vtbl;
        public DataView cvtbl;
        DataRow dr;
        DataRow t;
        DataRow[] tt;
        System.Threading.Timer clock;
        bool frst = true;
        public override void OnInitialization()
        {
            tbl.Columns.Add("Col1", typeof(int));
            tbl.Columns.Add("Col2", typeof(double));
            tbl.Columns.Add("Col3", typeof(int));
            tbl.Columns.Add("Price", typeof(System.Decimal));
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = tbl.Columns["Price"];
            tbl.PrimaryKey = PrimaryKeyColumns;
            runForm = new RunForm();
            oThread = new Thread(new ThreadStart(runForm.startForm));
            oThread.Start();
            tThread = new Thread(new ThreadStart(startTimer));
            tThread.Start();
        }
        void startTimer()
        {
            clock = new System.Threading.Timer(new TimerCallback(Timer_Tick));
            clock.Change(0, 1000);
            Thread.Sleep(Timeout.Infinite);
        }
        void Timer_Tick(object state)
        {
            if (frst == true)
            {
                ctbl.Merge(tbl);
                cvtbl = new DataView(ctbl);
                cvtbl.Sort = "Price DESC";
                frst = false;
                runForm.sampleForm.Invoke(runForm.sampleForm.dDelegateInitializeGrid,
                    vtbl);
            }
            Console.WriteLine("tick occured");
            ctbl.Merge(tbl);
        }
        public override void onDataArrival()
        {
            //update DataTable tbl
        }
        public override void OnStop()
        {
            runForm.stopForm();
            clock.Dispose();
            tThread.Abort();
        }
    }    
    
    public class RunForm
    {
        public Form1 sampleForm = null;
        public DataTable dtbl;
        public void startForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            sampleForm = new Form1();
            Application.Run(sampleForm);
        }
        public void stopForm()
        {
            sampleForm.Dispose();
        }
    }
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should bedisposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                //aTimer.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // initialize form and datagridview
        }
        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private void initializeGrid(DataView lst)
        {
            SetDoubleBuffered(dataGridView1);
            //this.DoubleBuffered = true;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.DataSource = lst;
        }
    }
    public partial class Form1 : Form
    {
        public DelegateInitializeGrid dDelegateInitializeGrid;
       
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dDelegateInitializeGrid = new DelegateInitializeGrid(this.initializeGrid);
        }
        public static void SetDoubleBuffered(Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
    }
}
