    public partial class FrmMain : Form
    {
        // public Form FrmModifyData; <-- do not declare it in your FrmMain 
        // (is't a modal dialog, so you won't get more instances)
        public int PersonCode {get; set;}
        public FrmMain()
        {
            InitializeComponent();
        }
        private void btnShowDataForm_Click(object sender, EventArgs e)
        {
            FrmData FrmModifyData = new FrmData();
            FrmModifyData.PersonCode = this.PersonCode;
            DialogResult result = FrmModifyData.ShowDialog();
            if(result == DialogResult.Ok)
            {
                // do something with the result
                this.PersonCode = FrmModifyData.PersonCode;
                
                
            }
        }
    }
