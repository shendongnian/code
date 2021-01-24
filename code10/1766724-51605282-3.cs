    // XtraReport
    public partial class ReportName : DevExpress.XtraReports.UI.XtraReport
    {
        // default parameterless constructor here
        public ReportName(string ClassName, string SubclassName, string StudentName)
        {
            InitializeComponent();
        
            this.Parameters["ClassName"].Value = ClassName;
            this.Parameters["SubclassName"].Value = SubclassName;
            this.Parameters["StudentName"].Value = StudentName;
        }
    }
    // Form code
    private void btnPrint_Click(object sender, EventArgs e)
    {
        // Create a report instance.
        var report = new XtraReport1(cmbClass.SelectedText, cmbDivision.SelectedText, cmbStudent.SelectedText);
    
        report.RequestParameters = false; // Hide the Parameters UI from end-users.
        report.ShowPreview();
    }
