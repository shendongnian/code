    //Caller Form
    private void ListEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //(...)
        Employee emp = new Employee().Get(row.Cells["Employee_ID"].Value.ToString());
        DimBackground overlay = new DimBackground(new Modal(emp));
        overlay.Show(this);
    }
    public partial class DimBackground : Form
    {
        Form frmDialog = null; 
        public DimBackground(Form dialog)
        {
            InitializeComponent();
            this.frmDialog = dialog;
            this.frmDialog.FormClosed += (obj, evt) => { this.Close(); };
        }
        private void DimBackground_Shown(object sender, EventArgs e) => this.frmDialog.ShowDialog();
        private void DimBackground_Load(object sender, EventArgs e)
        {
            if (this.Owner == null) return;
            this.Bounds = this.Owner.Bounds;
        }
        private void DimBackground_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner?.Activate();
        }
    }
    public partial class Modal : Form
    {
        public Modal() : this(null) { }
        public Modal(Employee employee)
        {
            InitializeComponent();
            // Do something with the employee object
        }
    }
